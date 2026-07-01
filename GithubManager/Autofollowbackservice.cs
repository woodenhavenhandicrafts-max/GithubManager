namespace GithubManager
{
    public class AutoFollowBackService
    {
        private readonly GitHubSocialManager _mgr;
        private readonly FollowTracker _tracker;
        private System.Windows.Forms.Timer _timer;
        private readonly HashSet<string> _alreadyFollowedBack = new(StringComparer.OrdinalIgnoreCase);

        public bool IsRunning => _timer?.Enabled ?? false;
        public DateTime? NextPollAt { get; private set; }

        public AutoFollowBackService(GitHubSocialManager mgr, FollowTracker tracker)
        {
            _mgr = mgr;
            _tracker = tracker;
        }

        public void Start(int intervalMinutes, Action<string> log)
        {
            if (IsRunning) return;
            _timer = new System.Windows.Forms.Timer { Interval = intervalMinutes * 60000 };
            NextPollAt = DateTime.Now.AddMilliseconds(_timer.Interval);
            _timer.Tick += async (s, e) =>
            {
                _timer.Stop();
                NextPollAt = null;
                log("Polling for new followers...");
                try
                {
                    var newOnes = await _mgr.GetNewFollowersNotFollowedBackAsync();
                    var toFollow = newOnes.Where(u => !_alreadyFollowedBack.Contains(u.Login)).ToList();

                    foreach (var u in toFollow)
                    {
                        try
                        {
                            await _mgr.FollowAsync(u.Login);
                            _tracker?.Record(u.Login);
                            _alreadyFollowedBack.Add(u.Login);
                            log($"Followed back: {u.Login}");
                            await Task.Delay(1500);
                        }
                        catch (Exception ex) { log($"Failed to follow back {u.Login}: {ex.Message}"); }
                    }

                    if (toFollow.Count == 0) log("No new followers to follow back.");
                }
                catch (Exception ex) { log($"Poll error: {ex.Message}"); }

                _timer.Interval = _timer.Interval; // keep same interval
                NextPollAt = DateTime.Now.AddMilliseconds(_timer.Interval);
                _timer.Start();
            };
            _timer.Start();
        }

        public void Stop()
        {
            _timer?.Stop();
            _timer?.Dispose();
            _timer = null;
            NextPollAt = null;
        }
    }
}