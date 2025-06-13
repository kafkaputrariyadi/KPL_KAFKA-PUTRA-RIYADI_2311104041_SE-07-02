using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul15_2311104041
{
    using System.Text.Json;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UserManager
    {
        private const string filePath = "user_data.json";
        private List<User> users = new List<User>();

        public UserManager()
        {
            LoadUsers();
        }

        public bool Register(string username, string password, out string errorMsg)
        {
            errorMsg = "";

            // Validasi panjang username
            if (username.Length < 4 || username.Length > 20 || !Regex.IsMatch(username, @"^[a-zA-Z]+$"))
            {
                errorMsg = "Username harus terdiri dari 4-20 huruf alfabet ASCII saja.";
                return false;
            }

            // Validasi panjang password
            if (password.Length < 8 || password.Length > 20)
            {
                errorMsg = "Password harus 8-20 karakter.";
                return false;
            }

            // Password tidak boleh mengandung username
            if (password.ToLower().Contains(username.ToLower()))
            {
                errorMsg = "Password tidak boleh mengandung username.";
                return false;
            }

            // Password harus mengandung angka dan karakter unik
            if (!Regex.IsMatch(password, @"\d") || !Regex.IsMatch(password, @"[!@#$%^&*]"))
            {
                errorMsg = "Password harus mengandung setidaknya 1 angka dan 1 karakter unik (!@#$%^&*).";
                return false;
            }

            if (users.Any(u => u.Username == username))
            {
                errorMsg = "Username sudah digunakan.";
                return false;
            }

            string hash = ComputeSha256Hash(password);
            users.Add(new User { Username = username, PasswordHash = hash });
            SaveUsers();
            return true;
        }

        public bool Login(string username, string password)
        {
            string hash = ComputeSha256Hash(password);
            return users.Any(u => u.Username == username && u.PasswordHash == hash);
        }

        private void LoadUsers()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
        }

        private void SaveUsers()
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Convert.ToHexString(bytes); // .NET 5+
            }
        }
    }
}