namespace AchievementUnlocker.Steam.Detection {
    internal sealed class NotRunBySteam : DetectionFailure {

        public override string ErrorDescription => "Application is not launched by Steam";

    }
}
