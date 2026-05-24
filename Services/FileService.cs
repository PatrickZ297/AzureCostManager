using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AzureCostManager.Classes;

namespace AzureCostManager.Services
{
    class FileService
    {
        private static string usersPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Data", "users.csv");

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();
            lines.Add("Username,PIN,Role");

            foreach (User u in users)
                lines.Add($"{u.Username},{u.GetPin()},{u.Role}");

            Directory.CreateDirectory(Path.GetDirectoryName(usersPath));
            File.WriteAllLines(usersPath, lines);
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            if (!File.Exists(usersPath)) return users;

            string[] lines = File.ReadAllLines(usersPath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3) continue;

                if (parts[2] == "Admin")
                    users.Add(new Admin(parts[0], parts[1]));
                else
                    users.Add(new Customer(parts[0], parts[1]));
            }

            return users;
        }
    }
}
