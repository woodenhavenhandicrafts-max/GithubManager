namespace GithubManager
{
    using System.Security.Cryptography;
    using System.Text;

    public static class TokenStorage
    {
        private static readonly string _dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GithubManager");
        private static readonly string _path = Path.Combine(_dir, "token.enc");

        public static void Save(string token)
        {
            Directory.CreateDirectory(_dir);
            var plain = Encoding.UTF8.GetBytes(token);
            var encrypted = ProtectedData.Protect(plain, null, DataProtectionScope.CurrentUser);
            File.WriteAllBytes(_path, encrypted);
        }

        public static string? Load()
        {
            if (!File.Exists(_path)) return null;
            try
            {
                var encrypted = File.ReadAllBytes(_path);
                var plain = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plain);
            }
            catch { return null; }
        }

        public static void Clear()
        {
            if (File.Exists(_path)) File.Delete(_path);
        }

        public static bool HasSaved() => File.Exists(_path);
    }
}