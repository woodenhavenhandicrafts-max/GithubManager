namespace GithubManager
{
    public enum AchievementStatus { Locked, InProgress, Unlocked }

    public class AchievementTier
    {
        public string Label { get; set; }
        public int Threshold { get; set; }
        public string BadgeEmoji { get; set; }
    }

    public class Achievement
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string HowTo { get; set; }
        public string ApiUrl { get; set; }
        public AchievementStatus Status { get; set; }
        public int Progress { get; set; }
        public int NextGoal { get; set; }
        public string CurrentTier { get; set; }
        public string Note { get; set; }
        public List<AchievementTier> Tiers { get; set; } = new();
    }

    public class AchievementChecker
    {
        private readonly Octokit.GitHubClient _client;
        private readonly string _username;

        public AchievementChecker(string token, string username)
        {
            _client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("GHSocialTool"))
            {
                Credentials = new Octokit.Credentials(token)
            };
            _username = username;
        }

        public async Task<List<Achievement>> CheckAllAsync(IProgress<string> progress)
        {
            var results = new List<Achievement>();

            progress.Report("Checking Starstruck...");
            results.Add(await CheckStarstruckAsync());

            progress.Report("Checking Pull Shark...");
            results.Add(await CheckPullSharkAsync());

            progress.Report("Checking Quickdraw...");
            results.Add(await CheckQuickdrawAsync());

            progress.Report("Checking Pair Extraordinaire...");
            results.Add(await CheckPairExtraordinaireAsync());

            progress.Report("Checking YOLO...");
            results.Add(CheckYolo());

            progress.Report("Checking Galaxy Brain...");
            results.Add(CheckGalaxyBrain());

            progress.Report("Checking Public Sponsor...");
            results.Add(await CheckPublicSponsorAsync());

            progress.Report("Checking Arctic Code Vault...");
            results.Add(await CheckArcticVaultAsync());

            progress.Report("Done.");
            return results;
        }

        // ---- Starstruck: earn stars on a single repo ----
        private async Task<Achievement> CheckStarstruckAsync()
        {
            var tiers = new List<AchievementTier>
            {
                new() { Label = "Default", Threshold = 16,   BadgeEmoji = "🌟" },
                new() { Label = "Bronze",  Threshold = 128,  BadgeEmoji = "🌟🥉" },
                new() { Label = "Silver",  Threshold = 512,  BadgeEmoji = "🌟🥈" },
                new() { Label = "Gold",    Threshold = 4096, BadgeEmoji = "🌟🥇" },
            };

            int maxStars = 0;
            string topRepo = "";
            try
            {
                var opts = new Octokit.ApiOptions { PageSize = 100, PageCount = 1 };
                var repos = await _client.Repository.GetAllForCurrent(opts);
                var best = repos.OrderByDescending(r => r.StargazersCount).FirstOrDefault();
                if (best != null) { maxStars = best.StargazersCount; topRepo = best.Name; }
            }
            catch { }

            return BuildTieredAchievement("Starstruck",
                "Have a repository starred by many users.",
                "Polish a repo with a great README, topics, and description — then share it.",
                "https://github.com/" + _username + "?tab=repositories",
                tiers, maxStars,
                $"Your top repo: {topRepo} ({maxStars} ⭐)");
        }

        // ---- Pull Shark: get PRs merged ----
        private async Task<Achievement> CheckPullSharkAsync()
        {
            var tiers = new List<AchievementTier>
            {
                new() { Label = "Default", Threshold = 2,    BadgeEmoji = "🦈" },
                new() { Label = "Bronze",  Threshold = 16,   BadgeEmoji = "🦈🥉" },
                new() { Label = "Silver",  Threshold = 128,  BadgeEmoji = "🦈🥈" },
                new() { Label = "Gold",    Threshold = 1024, BadgeEmoji = "🦈🥇" },
            };

            int mergedPRs = 0;
            try
            {
                var req = new Octokit.SearchIssuesRequest
                {
                    Author = _username,
                    Type = Octokit.IssueTypeQualifier.PullRequest,
                    Is = new[] { Octokit.IssueIsQualifier.Merged }
                };
                var result = await _client.Search.SearchIssues(req);
                mergedPRs = result.TotalCount;
            }
            catch { }

            return BuildTieredAchievement("Pull Shark",
                "Open pull requests that get merged.",
                "Contribute to open source projects — fix bugs, improve docs, add features.",
                $"https://github.com/search?q=author%3A{_username}+type%3Apr+is%3Amerged",
                tiers, mergedPRs,
                $"{mergedPRs} merged PRs found");
        }

        // ---- Quickdraw: close an issue/PR within 5 min ----
        private async Task<Achievement> CheckQuickdrawAsync()
        {
            bool found = false;
            string note = "Checking recent issue events...";
            try
            {
                var events = await _client.Activity.Events.GetAllUserPerformed(_username,
                    new Octokit.ApiOptions { PageSize = 100, PageCount = 1 });

                var closes = events.Where(e => e.Type == "IssuesEvent").ToList();
                // Can't get exact open→close time from events API alone; flag as manual check
                note = closes.Count > 0
                    ? $"Found {closes.Count} issue events — exact timing requires manual check on GitHub."
                    : "No recent issue events found.";
            }
            catch { note = "Could not fetch events."; }

            return new Achievement
            {
                Name = "Quickdraw",
                Description = "Close an issue or PR within 5 minutes of opening it.",
                HowTo = "Open an issue, realize it's a duplicate, close it immediately.",
                ApiUrl = $"https://github.com/{_username}",
                Status = AchievementStatus.InProgress,
                Progress = 0,
                NextGoal = 1,
                CurrentTier = "—",
                Note = note,
                Tiers = new List<AchievementTier>
                {
                    new() { Label = "Default", Threshold = 1, BadgeEmoji = "⚡" }
                }
            };
        }

        // ---- Pair Extraordinaire: co-authored commits ----
        private async Task<Achievement> CheckPairExtraordinaireAsync()
        {
            var tiers = new List<AchievementTier>
            {
                new() { Label = "Default", Threshold = 1,  BadgeEmoji = "👥" },
                new() { Label = "Bronze",  Threshold = 10, BadgeEmoji = "👥🥉" },
                new() { Label = "Silver",  Threshold = 24, BadgeEmoji = "👥🥈" },
                new() { Label = "Gold",    Threshold = 48, BadgeEmoji = "👥🥇" },
            };

            int coAuthored = 0;
            string note = "Requires co-authored commits (Co-authored-by: in commit message).";
            try
            {
                var req = new Octokit.SearchCodeRequest($"co-authored-by author:{_username}")
                {
                    PerPage = 100
                };
                var result = await _client.Search.SearchCode(req);
                coAuthored = result.TotalCount;
                note = $"~{coAuthored} co-authored commits found (GitHub search estimate).";
            }
            catch { note = "Search API rate limited or unavailable."; }

            return BuildTieredAchievement("Pair Extraordinaire",
                "Co-author commits with another GitHub user.",
                "Add 'Co-authored-by: name <email>' to commit messages when pair programming.",
                $"https://github.com/{_username}",
                tiers, coAuthored, note);
        }

        // ---- YOLO: merge a PR without review ----
        private Achievement CheckYolo()
        {
            return new Achievement
            {
                Name = "YOLO",
                Description = "Merge a pull request without a code review.",
                HowTo = "On a repo you own, merge a PR with no reviewers assigned.",
                ApiUrl = $"https://github.com/{_username}?tab=repositories",
                Status = AchievementStatus.InProgress,
                Progress = 0,
                NextGoal = 1,
                CurrentTier = "—",
                Note = "Cannot be checked via API — verify manually on GitHub.",
                Tiers = new List<AchievementTier>
                {
                    new() { Label = "Default", Threshold = 1, BadgeEmoji = "🤞" }
                }
            };
        }

        // ---- Galaxy Brain: discussion answer accepted ----
        private Achievement CheckGalaxyBrain()
        {
            return new Achievement
            {
                Name = "Galaxy Brain",
                Description = "Have an answer marked as the correct answer in GitHub Discussions.",
                HowTo = "Answer questions in repositories that use GitHub Discussions.",
                ApiUrl = $"https://github.com/{_username}",
                Status = AchievementStatus.InProgress,
                Progress = 0,
                NextGoal = 2,
                CurrentTier = "—",
                Note = "Requires GraphQL API — cannot be checked via REST. Check your profile manually.",
                Tiers = new List<AchievementTier>
                {
                    new() { Label = "Default", Threshold = 2,  BadgeEmoji = "🧠" },
                    new() { Label = "Bronze",  Threshold = 8,  BadgeEmoji = "🧠🥉" },
                    new() { Label = "Silver",  Threshold = 16, BadgeEmoji = "🧠🥈" },
                    new() { Label = "Gold",    Threshold = 32, BadgeEmoji = "🧠🥇" },
                }
            };
        }

        // ---- Public Sponsor ----
        private async Task<Achievement> CheckPublicSponsorAsync()
        {
            bool isSponsoring = false;
            string note = "";
            try
            {
                // Check via user's sponsoring list (GraphQL-only, REST fallback via profile)
                var user = await _client.User.Get(_username);
                note = "Sponsoring status requires GraphQL — check github.com/sponsors manually.";
            }
            catch { note = "Could not fetch user data."; }

            return new Achievement
            {
                Name = "Public Sponsor",
                Description = "Sponsor another GitHub user or organization.",
                HowTo = "Go to any developer's profile and click 'Sponsor'.",
                ApiUrl = "https://github.com/sponsors",
                Status = isSponsoring ? AchievementStatus.Unlocked : AchievementStatus.InProgress,
                Progress = isSponsoring ? 1 : 0,
                NextGoal = 1,
                CurrentTier = isSponsoring ? "Unlocked ✔" : "—",
                Note = note,
                Tiers = new List<AchievementTier>
                {
                    new() { Label = "Default", Threshold = 1, BadgeEmoji = "💝" }
                }
            };
        }

        // ---- Arctic Code Vault ----
        private async Task<Achievement> CheckArcticVaultAsync()
        {
            bool eligible = false;
            string note = "";
            try
            {
                var user = await _client.User.Get(_username);
                eligible = user.CreatedAt.Year <= 2020;
                note = eligible
                    ? $"Account created {user.CreatedAt:yyyy-MM-dd} — eligible if you had public code before Feb 2020."
                    : $"Account created {user.CreatedAt:yyyy-MM-dd} — after the 2020 snapshot, not eligible.";
            }
            catch { note = "Could not check."; }

            return new Achievement
            {
                Name = "Arctic Code Vault Contributor",
                Description = "Contributed code to the 2020 GitHub Arctic Code Vault.",
                HowTo = "This achievement is no longer earnable — it was a one-time 2020 snapshot.",
                ApiUrl = "https://archiveprogram.github.com/",
                Status = eligible ? AchievementStatus.InProgress : AchievementStatus.Locked,
                Progress = 0,
                NextGoal = 1,
                CurrentTier = "—",
                Note = note,
                Tiers = new List<AchievementTier>
                {
                    new() { Label = "Default", Threshold = 1, BadgeEmoji = "🧊" }
                }
            };
        }

        // ---- Helper ----
        private Achievement BuildTieredAchievement(string name, string desc, string howTo,
            string url, List<AchievementTier> tiers, int progress, string note)
        {
            var unlocked = tiers.Where(t => progress >= t.Threshold).ToList();
            var next = tiers.FirstOrDefault(t => progress < t.Threshold);

            var status = unlocked.Count == tiers.Count ? AchievementStatus.Unlocked
                       : unlocked.Count > 0 ? AchievementStatus.InProgress
                       : AchievementStatus.Locked;

            return new Achievement
            {
                Name = name,
                Description = desc,
                HowTo = howTo,
                ApiUrl = url,
                Status = status,
                Progress = progress,
                NextGoal = next?.Threshold ?? tiers.Last().Threshold,
                CurrentTier = unlocked.LastOrDefault()?.Label ?? "None",
                Note = note,
                Tiers = tiers
            };
        }
    }
}