using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCostManager.Classes
{
    public class User
    {
        private string username;
        private string pin;
        private string role;

        public string Username => username;
        public string Role => role;

        public User(string username, string pin, string role) 
        { 
            this.username = username;
            this.pin = pin;
            this.role = role;
        }

        public bool Login (string eingabePin)
        {
            return this.pin == eingabePin;
        }

        public string GetPin()
        {
            return pin;
        }

        public virtual void ShowProfile()
        {
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Role: {role}");
        }
    }
}
