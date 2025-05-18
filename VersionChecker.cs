using System;
using System.Net;

namespace WorldSpecialDaysCountdown
{
    public static class VersionChecker
    {
        /// <summary>
        /// Gets the latest version number from the GitHub API.
        /// </summary>
        /// <returns></returns>
        public static string GetNewVersionNumberFromGithubAPI()
        {
            var c = new WebClient();
            c.Headers.Add("User-Agent", "GitHubAutoUpdateTest");
            var s = c.DownloadString("https://api.github.com/repos/JoshuaMaitland/WorldSpecialDaysCountdown/releases/latest");
            var versionTag = s.Split(new string[] { "\"tag_name\":\"" }, StringSplitOptions.None)[1].Split('"')[0];

            // Remove leading 'v' if present
            var versionNumber = versionTag.StartsWith("v", StringComparison.OrdinalIgnoreCase)
                ? versionTag.Substring(1)
                : versionTag;

            return versionNumber;
        }
    }
}
