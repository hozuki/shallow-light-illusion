namespace AchievementUnlocker.Steam.Detection {
    internal abstract class DetectionFailure : DetectionResult {

        private protected DetectionFailure() {
        }

        public sealed override bool IsSuccessful => false;

    }
}
