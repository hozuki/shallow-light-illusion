using System;
using System.Windows.Forms;
using AchievementUnlocker.Forms;
using AchievementUnlocker.Steam;

namespace AchievementUnlocker {
    internal static class Program {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main() {
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var detection = SteamHelper.TryInitSteam();

            if (detection.IsSuccessful) {
                using (var form2 = new Form2()) {
                    Application.Run(form2);
                }
            } else {
                using (var form1 = new Form1()) {
                    form1.DetectionResult = detection;
                    Application.Run(form1);
                }
            }
        }

        public static readonly string Title = "Achievement Unlocker";

    }
}
