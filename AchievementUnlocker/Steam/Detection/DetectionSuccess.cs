namespace AchievementUnlocker.Steam.Detection {
    internal sealed class DetectionSuccess : DetectionResult {

        public override bool IsSuccessful => true;

        public override string ErrorDescription => string.Empty;

    }
}
