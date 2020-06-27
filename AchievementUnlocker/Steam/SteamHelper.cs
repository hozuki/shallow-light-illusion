using AchievementUnlocker.Steam.Detection;
using Steamworks;

namespace AchievementUnlocker.Steam {
    internal static class SteamHelper {

        public static DetectionResult TryInitSteam() {
            if (SteamAPI.Init()) {
                return DetectionResult.Ok();
            }

            if (!SteamAPI.IsSteamRunning()) {
                return DetectionResult.SteamNotRunning();
            }

            return DetectionResult.NotRunBySteam();
        }

    }
}
