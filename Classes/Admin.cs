using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCostManager.Classes
{
    public class Admin : User
    {
        public Admin(string username, string pin)
            : base(username, pin, "Admin")
        {
        }

        public void CreateUser(List<User> users, string username, string pin, string role)
        {
            bool existiert = users.Find(u => u.Username.ToLower() == username.ToLower()) != null;

            if (existiert)
            {
                Console.WriteLine($"Username '{username}' already exists!");
                return;
            }

            if (role == "Admin")
                users.Add(new Admin(username, pin));
            else
                users.Add(new Customer(username, pin));

            Console.WriteLine($"User '{username}' successfully created!");
        }

        public void DeleteUser(List<User> users, string username)
        {
            User user = users.Find(u => u.Username == username);

            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            users.Remove(user);
            Console.WriteLine($"User '{username}' successfully deleted!");
        }

        public void ShowStatistics(List<User> users)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("           Statistics            ");
            Console.WriteLine("=================================");
            Console.WriteLine($"Total Users: {users.Count}");
            Console.WriteLine($"Admins:      {users.Count(u => u.Role == "Admin")}");
            Console.WriteLine($"Customers:   {users.Count(u => u.Role == "Customer")}");
            Console.WriteLine("=================================");
        }

        public override void ShowProfile()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("         Admin Profile           ");
            Console.WriteLine("=================================");
            base.ShowProfile();
            Console.WriteLine("=================================");
        }
    }
}
