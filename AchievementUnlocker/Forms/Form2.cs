using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AchievementUnlocker.Steam;
using Steamworks;
using Timer = System.Threading.Timer;

namespace AchievementUnlocker.Forms {
    public partial class Form2 : Form {

        private Timer _timer;

        public Form2() {
            InitializeComponent();

            _timer = new Timer(TimerCallback, null, 0, 100);

            RegisterEventHandlers();
        }

        private static void TimerCallback(object state) {
            SteamAPI.RunCallbacks();
        }

        private void RegisterEventHandlers() {
            Load += Form2_Load;
            Closed += Form2_Closed;
            btnSelAll.Click += BtnSelAll_Click;
            btnUnlock.Click += BtnUnlock_Click;
            lv.ItemChecked += Lv_ItemChecked;
        }

        private void Lv_ItemChecked(object sender, ItemCheckedEventArgs e) {
            UpdateStatsText();
        }

        private void BtnUnlock_Click(object sender, EventArgs e) {
            var achToUnlock = new List<AchievementInfo>();

            foreach (ListViewItem lvi in lv.Items) {
                if (!lvi.Checked) {
                    continue;
                }

                var ach = (AchievementInfo)lvi.Tag;

                if (!ach.IsAchieved) {
                    achToUnlock.Add(ach);
                }
            }

            if (achToUnlock.Count == 0) {
                MessageBox.Show("No locked achievement to unlock.", Program.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            {
                var sb = new StringBuilder();
                sb.AppendLine("Will unlock achievement(s):");

                sb.AppendLine();

                foreach (var ach in achToUnlock) {
                    sb.AppendLine(ach.DisplayName);
                }

                sb.AppendLine();
                sb.Append("Confirm?");

                var message = sb.ToString();

                var r = MessageBox.Show(message, Program.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (r == DialogResult.No) {
                    return;
                }
            }

            foreach (var ach in achToUnlock) {
                var successful = SteamUserStats.SetAchievement(ach.ApiName);

                if (!successful) {
                    var message = $"Error occurred while unlocking achievement: {ach.DisplayName}. Aborting.";
                    MessageBox.Show(message, Program.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

#pragma warning disable 4014
            ReloadAchievementsAsync(false);
#pragma warning restore 4014
        }

        private void BtnSelAll_Click(object sender, EventArgs e) {
            foreach (ListViewItem lvi in lv.Items) {
                var ach = (AchievementInfo)lvi.Tag;
                lvi.Checked = !ach.IsAchieved;
            }

            UpdateStatsText();
        }

        private void Form2_Load(object sender, EventArgs e) {
            var appId = SteamUtils.GetAppID();
            lblAppId.Text = appId.m_AppId.ToString();

            var userName = SteamFriends.GetPersonaName();
            var userId = SteamUser.GetSteamID().GetAccountID();
            lblAccountInfo.Text = $"{userName} (ID: {userId.ToString()})";

#pragma warning disable 4014
            ReloadAchievementsAsync(true);
#pragma warning restore 4014
        }

        private void Form2_Closed(object sender, EventArgs e) {
            _timer.Dispose();
            SteamAPI.Shutdown();
        }

        private void UpdateStatsText() {
            var achCount = lv.Items.Count;
            var achievedCount = 0;
            var selectedCount = 0;

            foreach (ListViewItem lvi in lv.Items) {
                if (lvi.Checked) {
                    selectedCount += 1;
                }

                var ach = (AchievementInfo)lvi.Tag;

                if (ach.IsAchieved) {
                    achievedCount += 1;
                }
            }

            var text = $"Achieved: {achievedCount.ToString()}/{achCount.ToString()}; Selected {selectedCount.ToString()}";
            lblStats.Text = text;
        }

        private async Task ReloadAchievementsAsync(bool reloadImages) {
            EnableInteraction(false);

            lv.Items.Clear();

            var achCount = SteamUserStats.GetNumAchievements();
            var achIds = new List<string>();

            for (var i = 0u; i < achCount; i += 1) {
                var achId = SteamUserStats.GetAchievementName(i);
                achIds.Add(achId);
            }

            foreach (var achId in achIds) {
                Bitmap icon = null;

                if (reloadImages) {
                    icon = await GetAchievementIconAsync(achId);

                    if (icon != null) {
                        iml.Images.Add(achId, icon);
                    }
                }

                var ach = AchievementInfo.Query(achId);

                var lvi = new ListViewItem();
                lvi.Text = ach.DisplayName;

                if (icon != null || !reloadImages) {
                    lvi.ImageKey = achId;
                }

                lvi.SubItems.Add(BoolToStr(ach.IsAchieved));

                lvi.SubItems.Add(ach.Description);
                lvi.SubItems.Add(ach.ApiName);
                lvi.SubItems.Add(BoolToStr(ach.IsHidden));

                lvi.Tag = ach;

                lv.Items.Add(lvi);
            }

            lblStats.Visible = true;
            UpdateStatsText();

            EnableInteraction(true);
        }

        private static Task<Bitmap> GetAchievementIconAsync(string achId) {
            Bitmap result = null;
            Callback<UserAchievementIconFetched_t> callback = null;
            AutoResetEvent ev = null;

            void OnIconFetched(UserAchievementIconFetched_t e) {
                result = GetBitmapFromHandle(e.m_nIconHandle);
                // Intentional
                // ReSharper disable once AccessToModifiedClosure
                callback?.Dispose();
                ev?.Set();
            }

            var iconHandle = SteamUserStats.GetAchievementIcon(achId);

            if (iconHandle != 0) {
                result = GetBitmapFromHandle(iconHandle);
            } else {
                try {
                    ev = new AutoResetEvent(false);
                    callback = new Callback<UserAchievementIconFetched_t>(OnIconFetched);
                    ev.WaitOne();
                } finally {
                    ev?.Dispose();
                }
            }

            return Task.FromResult(result);
        }

        private static Bitmap GetBitmapFromHandle(int iconHandle) {
            if (iconHandle == 0) {
                return null;
            }

            SteamUtils.GetImageSize(iconHandle, out var width, out var height);

            var bufferSize = (int)(width * height * 4);
            var buffer = new byte[bufferSize];

            SteamUtils.GetImageRGBA(iconHandle, buffer, bufferSize);

            // Flip RGBA (Steam) to ARGB (GDI+)
            unsafe {
                fixed (byte* p = buffer) {
                    for (var i = 0; i < bufferSize; i += 4) {
                        var a = p[i + 3];
                        var b = p[i + 2];
                        var g = p[i + 1];
                        var r = p[i + 0];

                        p[i + 3] = a;
                        p[i + 2] = r;
                        p[i + 1] = g;
                        p[i + 0] = b;
                    }
                }
            }

            var bitmap = new Bitmap((int)width, (int)height);

            BitmapData locked = null;

            try {
                locked = bitmap.LockBits(new Rectangle(0, 0, (int)width, (int)height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                unsafe {
                    fixed (byte* src0 = buffer) {
                        var dst0 = (byte*)locked.Scan0.ToPointer();
                        var stride = locked.Stride;
                        var copied = 0;
                        var counter = 0;

                        while (copied < bufferSize) {
                            var src = src0 + counter * (width * 4);
                            var dst = dst0 + counter * stride;

                            Buffer.MemoryCopy(src, dst, stride, stride);

                            copied += stride;
                            counter += 1;
                        }
                    }
                }
            } finally {
                if (locked != null) {
                    bitmap.UnlockBits(locked);
                }
            }

            return bitmap;
        }

        private static string BoolToStr(bool b) {
            return b ? "Yes" : "No";
        }

        private void EnableInteraction(bool enabled) {
            lv.Enabled = enabled;
            btnSelAll.Enabled = enabled;
            btnUnlock.Enabled = enabled;
        }

    }
}
