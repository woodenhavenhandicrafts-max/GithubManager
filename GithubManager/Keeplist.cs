namespace GithubManager
{
    using System.Text.Json;

    public class KeepList
    {
        private readonly string _path;
        private Dictionary<string, DateTime> _entries; // login -> date added

        public KeepList(string username)
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GithubManager");
            Directory.CreateDirectory(dir);
            _path = Path.Combine(dir, $"keep_list_{username}.json");
            Load();
        }

        private void Load()
        {
            if (!File.Exists(_path)) { _entries = new(); return; }
            try
            {
                var json = File.ReadAllText(_path);
                _entries = JsonSerializer.Deserialize<Dictionary<string, DateTime>>(json) ?? new();
            }
            catch { _entries = new(); }
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public void Add(string login)
        {
            _entries[login] = DateTime.UtcNow;
            Save();
        }

        public void Remove(string login)
        {
            _entries.Remove(login);
            Save();
        }

        public bool Contains(string login) =>
            _entries.ContainsKey(login);

        public DateTime? DateAdded(string login) =>
            _entries.TryGetValue(login, out var dt) ? dt : null;

        public IReadOnlyDictionary<string, DateTime> All => _entries;
    }
}