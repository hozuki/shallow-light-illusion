namespace AchievementUnlocker.Steam.Detection {
    internal abstract class DetectionResult {

        private protected DetectionResult() {
        }

        public abstract bool IsSuccessful { get; }

        public abstract string ErrorDescription { get; }

        public static DetectionResult Ok() => new DetectionSuccess();

        public static DetectionResult SteamNotRunning() => new SteamNotRunning();

        public static DetectionResult NotRunBySteam() => new NotRunBySteam();

    }
}
