namespace GithubManager
{
    public class FollowCrawler
    {
        private readonly GitHubSocialManager _mgr;
        private readonly FollowTracker _tracker;
        private readonly Random _rng = new();
        private System.Windows.Forms.Timer _timer;
        private readonly Queue<string> _candidates;
        private int _dailyCount = 0;
        private readonly int _dailyCap;
        private readonly int _minIntervalMs;
        private readonly int _maxIntervalMs;

        public bool IsRunning => _timer?.Enabled ?? false;
        public int DailyCount => _dailyCount;
        public int RemainingCandidates => _candidates.Count;
        public DateTime? NextFollowAt { get; private set; }

        public FollowCrawler(GitHubSocialManager mgr, FollowTracker tracker,
            IEnumerable<string> candidateLogins,
            int dailyCap = 50, int minIntervalMs = 60000, int maxIntervalMs = 300000)
        {
            _mgr = mgr;
            _tracker = tracker;
            _candidates = new Queue<string>(candidateLogins);
            _dailyCap = dailyCap;
            _minIntervalMs = minIntervalMs;
            _maxIntervalMs = maxIntervalMs;
        }

        public void Start(Action<string> log)
        {
            if (IsRunning) return;

            _timer = new System.Windows.Forms.Timer { Interval = _rng.Next(_minIntervalMs, _maxIntervalMs) };
            NextFollowAt = DateTime.Now.AddMilliseconds(_timer.Interval);
            _timer.Tick += async (s, e) =>
            {
                if (_dailyCount >= _dailyCap || _candidates.Count == 0)
                {
                    log(_dailyCount >= _dailyCap ? "Daily cap reached. Stopping." : "Candidate queue empty. Stopping.");
                    Stop();
                    return;
                }

                _timer.Stop();
                NextFollowAt = null;
                var login = _candidates.Dequeue();
                try
                {
                    await _mgr.FollowAsync(login);
                    _tracker?.Record(login);
                    _dailyCount++;
                    log($"Followed {login} ({_dailyCount}/{_dailyCap})");
                }
                catch (Exception ex)
                {
                    log($"Failed to follow {login}: {ex.Message}");
                }

                if (_dailyCount < _dailyCap && _candidates.Count > 0)
                {
                    _timer.Interval = _rng.Next(_minIntervalMs, _maxIntervalMs);
                    NextFollowAt = DateTime.Now.AddMilliseconds(_timer.Interval);
                    _timer.Start();
                }
            };
            _timer.Start();
        }

        public void Stop()
        {
            _timer?.Stop();
            _timer?.Dispose();
            _timer = null;
            NextFollowAt = null;
        }

        public void ResetDailyCount() => _dailyCount = 0;
    }
}