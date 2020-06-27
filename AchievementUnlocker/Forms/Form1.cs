using System;
using System.Windows.Forms;
using AchievementUnlocker.Steam.Detection;
using Steamworks;

namespace AchievementUnlocker.Forms {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            RegisterEventHandlers();
        }

        private void RegisterEventHandlers() {
            Load += Form1_Load;
            btnRelaunch.Click += BtnRelaunch_Click;
        }

        private void Form1_Load(object sender, EventArgs e) {
            lblErrDesc.Text = DetectionResult.ErrorDescription;
        }

        private void BtnRelaunch_Click(object sender, EventArgs e) {
            if (!VerifyInput()) {
                return;
            }

            if (Relaunch()) {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        internal DetectionResult DetectionResult { private get; set; }

        private bool VerifyInput() {
            if (!uint.TryParse(textBox1.Text, out var u)) {
                MessageBox.Show("Please enter a valid unsigned integer as AppID.", Program.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (u == 0) {
                MessageBox.Show("AppID cannot be 0.", Program.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool Relaunch() {
            var appId = uint.Parse(textBox1.Text);

            if (!SteamAPI.RestartAppIfNecessary(new AppId_t(appId))) {
                MessageBox.Show("Cannot relaunch.", Program.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}
