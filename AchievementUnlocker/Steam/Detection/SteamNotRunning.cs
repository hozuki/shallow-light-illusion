namespace AchievementUnlocker.Steam.Detection {
    internal sealed class SteamNotRunning : DetectionFailure {

        public override string ErrorDescription => "Steam is not running";

    }
}
