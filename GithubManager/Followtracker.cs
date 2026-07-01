namespace GithubManager
{
    using System.Text.Json;

    public class FollowTracker
    {
        private readonly string _path;
        private Dictionary<string, DateTime> _log;

        public FollowTracker(string username)
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GithubManager");
            Directory.CreateDirectory(dir);
            _path = Path.Combine(dir, $"follow_log_{username}.json");
            Load();
        }

        private void Load()
        {
            if (!File.Exists(_path)) { _log = new(); return; }
            try
            {
                var json = File.ReadAllText(_path);
                _log = JsonSerializer.Deserialize<Dictionary<string, DateTime>>(json) ?? new();
            }
            catch { _log = new(); }
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public void Record(string login)
        {
            _log[login] = DateTime.UtcNow;
            Save();
        }

        public DateTime? GetFollowDate(string login) =>
            _log.TryGetValue(login, out var dt) ? dt : null;

        public int? DaysFollowing(string login)
        {
            var dt = GetFollowDate(login);
            return dt.HasValue ? (int)(DateTime.UtcNow - dt.Value).TotalDays : null;
        }

        public string FormatAge(string login)
        {
            var dt = GetFollowDate(login);
            if (!dt.HasValue) return "unknown";
            var age = DateTime.UtcNow - dt.Value;
            if (age.TotalDays < 1) return "today";
            if (age.TotalDays < 7) return $"{(int)age.TotalDays}d ago";
            if (age.TotalDays < 30) return $"{(int)(age.TotalDays / 7)}w ago";
            if (age.TotalDays < 365) return $"{(int)(age.TotalDays / 30)}mo ago";
            return $"{(int)(age.TotalDays / 365)}y ago";
        }

        public IReadOnlyDictionary<string, DateTime> All => _log;
    }
}