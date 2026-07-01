namespace GithubManager
{
    public class GitHubSocialManager
    {
        private readonly Octokit.GitHubClient _client;
        private readonly string _username;

        public GitHubSocialManager(string token, string username)
        {
            _client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("GHSocialTool"))
            {
                Credentials = new Octokit.Credentials(token)
            };
            _username = username;
        }

        // ---- Followers / Following ----

        public async Task<List<Octokit.User>> GetFollowersAsync()
        {
            var all = new List<Octokit.User>();
            var options = new Octokit.ApiOptions { PageSize = 100 };
            int page = 1;
            while (true)
            {
                options.StartPage = page;
                var batch = await _client.User.Followers.GetAll(_username, options);
                if (batch.Count == 0) break;
                all.AddRange(batch);
                page++;
            }
            return all;
        }

        public async Task<List<Octokit.User>> GetFollowingAsync()
        {
            var all = new List<Octokit.User>();
            var options = new Octokit.ApiOptions { PageSize = 100 };
            int page = 1;
            while (true)
            {
                options.StartPage = page;
                var batch = await _client.User.Followers.GetAllFollowingForCurrent(options);
                if (batch.Count == 0) break;
                all.AddRange(batch);
                page++;
            }
            return all;
        }

        public async Task<List<Octokit.User>> GetFollowersOfAsync(string targetLogin, Func<List<Octokit.User>, Task<bool>> onPage = null)
        {
            var all = new List<Octokit.User>();
            var options = new Octokit.ApiOptions { PageSize = 100 };
            int page = 1;
            while (true)
            {
                options.StartPage = page;
                var batch = await _client.User.Followers.GetAll(targetLogin, options);
                if (batch.Count == 0) break;
                all.AddRange(batch);
                if (onPage != null)
                {
                    bool keepGoing = await onPage(batch.ToList());
                    if (!keepGoing) break;
                }
                page++;
            }
            return all;
        }

        public async Task<List<Octokit.User>> GetFollowingOfAsync(string targetLogin, Func<List<Octokit.User>, Task<bool>> onPage = null)
        {
            var all = new List<Octokit.User>();
            var options = new Octokit.ApiOptions { PageSize = 100 };
            int page = 1;
            while (true)
            {
                options.StartPage = page;
                var batch = await _client.User.Followers.GetAllFollowing(targetLogin, options);
                if (batch.Count == 0) break;
                all.AddRange(batch);
                if (onPage != null)
                {
                    bool keepGoing = await onPage(batch.ToList());
                    if (!keepGoing) break;
                }
                page++;
            }
            return all;
        }

        public async Task<(List<Octokit.User> notFollowingBack, List<Octokit.User> notFollowedYet)> DiffAsync()
        {
            var followers = await GetFollowersAsync();
            var following = await GetFollowingAsync();

            var followerLogins = followers.Select(u => u.Login).ToHashSet(StringComparer.OrdinalIgnoreCase);
            var followingLogins = following.Select(u => u.Login).ToHashSet(StringComparer.OrdinalIgnoreCase);

            var notFollowingBack = following.Where(u => !followerLogins.Contains(u.Login)).ToList();
            var notFollowedYet = followers.Where(u => !followingLogins.Contains(u.Login)).ToList();

            return (notFollowingBack, notFollowedYet);
        }

        // ---- Follow / Unfollow ----

        public async Task<Octokit.User> GetFullProfileAsync(string login) => await _client.User.Get(login);
        public async Task UnfollowAsync(string login) => await _client.User.Followers.Unfollow(login);
        public async Task FollowAsync(string login) => await _client.User.Followers.Follow(login);

        public async Task<int> GetRemainingRateLimitAsync()
        {
            var limits = await _client.RateLimit.GetRateLimits();
            return limits.Resources.Core.Remaining;
        }

        public async Task MassUnfollowAsync(IEnumerable<Octokit.User> users, IProgress<string> progress, CancellationToken ct)
        {
            foreach (var u in users)
            {
                ct.ThrowIfCancellationRequested();
                await UnfollowAsync(u.Login);
                progress?.Report($"Unfollowed {u.Login}");
                await Task.Delay(1200, ct);
            }
        }

        public async Task MassFollowAsync(IEnumerable<Octokit.User> users, IProgress<string> progress, CancellationToken ct)
        {
            foreach (var u in users)
            {
                ct.ThrowIfCancellationRequested();
                await FollowAsync(u.Login);
                progress?.Report($"Followed {u.Login}");
                await Task.Delay(1200, ct);
            }
        }

        // ---- Auto Follow-Back ----

        public async Task<List<Octokit.User>> GetNewFollowersNotFollowedBackAsync()
        {
            var followers = await GetFollowersAsync();
            var following = await GetFollowingAsync();
            var followingSet = following.Select(u => u.Login).ToHashSet(StringComparer.OrdinalIgnoreCase);
            return followers.Where(u => !followingSet.Contains(u.Login)).ToList();
        }

        // ---- Star-Back ----

        public async Task<List<Octokit.Repository>> GetReposForUserAsync(string login, int maxPages = 1)
        {
            var all = new List<Octokit.Repository>();
            var opts = new Octokit.ApiOptions { PageSize = 100, PageCount = maxPages, StartPage = 1 };
            var batch = await _client.Repository.GetAllForUser(login, opts);
            all.AddRange(batch);
            return all.OrderByDescending(r => r.StargazersCount).ToList();
        }

        public async Task<bool> IsStarredAsync(string owner, string repo)
        {
            try { return await _client.Activity.Starring.CheckStarred(owner, repo); }
            catch { return false; }
        }

        public async Task StarRepoAsync(string owner, string repo) =>
            await _client.Activity.Starring.StarRepo(owner, repo);

        public async Task UnstarRepoAsync(string owner, string repo) =>
            await _client.Activity.Starring.RemoveStarFromRepo(owner, repo);

        public async Task<List<Octokit.Repository>> GetMyStarredReposAsync()
        {
            var opts = new Octokit.ApiOptions { PageSize = 100 };
            var all = new List<Octokit.Repository>();
            int page = 1;
            while (true)
            {
                opts.StartPage = page;
                var batch = await _client.Activity.Starring.GetAllForCurrent(opts);
                if (batch.Count == 0) break;
                all.AddRange(batch);
                page++;
            }
            return all;
        }

        // ---- Repo Health ----

        public async Task<List<Octokit.Repository>> GetMyReposAsync()
        {
            var opts = new Octokit.ApiOptions { PageSize = 100 };
            var all = new List<Octokit.Repository>();
            int page = 1;
            while (true)
            {
                opts.StartPage = page;
                var batch = await _client.Repository.GetAllForCurrent(opts);
                if (batch.Count == 0) break;
                all.AddRange(batch);
                page++;
            }
            return all;
        }

        public async Task<bool> HasReadmeAsync(string owner, string repo)
        {
            try { await _client.Repository.Content.GetReadme(owner, repo); return true; }
            catch (Octokit.NotFoundException) { return false; }
        }

        public async Task<IReadOnlyList<string>> GetTopicsAsync(string owner, string repo)
        {
            var t = await _client.Repository.GetAllTopics(owner, repo);
            return t.Names;
        }

        public async Task SetTopicsAsync(string owner, string repo, string[] topics) =>
            await _client.Repository.ReplaceAllTopics(owner, repo, new Octokit.RepositoryTopics(topics));
    }
}