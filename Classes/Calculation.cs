using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCostManager.Classes
{
    public class Calculation
    {
        private string username;
        private DateTime date;
        private List<Resource> resources = new List<Resource>();
        private List<double> quantities = new List<double>();

        public string Username => username;
        public DateTime Date => date;
        public double TotalCost => CalculateTotalCost();

        public Calculation(string username)
        {
            this.username = username;
            this.date = DateTime.Now;
        }

        public void AddResource(Resource resource, double quantity)
        {
            resources.Add(resource);
            quantities.Add(quantity);
        }

        private double CalculateTotalCost()
        {
            double total = 0;
            for (int i = 0; i < resources.Count; i++)
                total += resources[i].CalculateCost(quantities[i]);
            return total;
        }

        public void ShowSummary()
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Date:     {date:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Customer: {username}");
            Console.WriteLine("---------------------------------");

            for (int i = 0; i < resources.Count; i++)
                Console.WriteLine($"{resources[i].Name}: {quantities[i]} {resources[i].Unit} = {resources[i].CalculateCost(quantities[i]):F2} EUR");

            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Total:    {TotalCost:F2} EUR");
            Console.WriteLine("=================================");
        }
    }
}
