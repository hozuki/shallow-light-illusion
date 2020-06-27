using System;
using Steamworks;

namespace AchievementUnlocker.Steam {
    internal sealed class AchievementInfo {

        private AchievementInfo(string apiName, string displayName, string description, bool isAchieved, bool isHidden) {
            ApiName = apiName;
            DisplayName = displayName;
            Description = description;
            IsAchieved = isAchieved;
            IsHidden = isHidden;
        }

        public string ApiName { get; }

        public string DisplayName { get; }

        public string Description { get; }

        public bool IsAchieved { get; }

        public bool IsHidden { get; }

        public static AchievementInfo Query(string achId) {
            var achName = SteamUserStats.GetAchievementDisplayAttribute(achId, "name");
            var achDesc = SteamUserStats.GetAchievementDisplayAttribute(achId, "desc");
            var hiddenStr = SteamUserStats.GetAchievementDisplayAttribute(achId, "hidden");
            var hidden = BoolFromIntStr(hiddenStr);
            SteamUserStats.GetAchievement(achId, out var achieved);

            return new AchievementInfo(achId, achName, achDesc, achieved, hidden);
        }

        private static bool BoolFromIntStr(string s) {
            switch (s) {
                case "0":
                    return false;
                case "1":
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(s));
            }
        }

    }
}
