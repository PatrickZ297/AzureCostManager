using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCostManager.Classes
{
    public class Customer : User
    {
        private List<Calculation> calculations = new List<Calculation>();

        public Customer(string username, string pin)
            : base(username, pin, "Customer")
        {
        }

        public void NewCalculation(List<Resource> resources)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("       New Calculation           ");
            Console.WriteLine("=================================");

            Calculation calculation = new Calculation(Username);

            while (true)
            {
                Console.WriteLine("\nAvailable Resources:");
                for (int i = 0; i < resources.Count; i++)
                    Console.WriteLine($"{i + 1}. {resources[i].Name} - {resources[i].PricePerUnit:F2} EUR/{resources[i].Unit}");

                Console.WriteLine("0. Finish calculation");
                Console.WriteLine("Your choice:");

                bool gültig = int.TryParse(Console.ReadLine(), out int auswahl);

                if (!gültig || auswahl < 0 || auswahl > resources.Count)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (auswahl == 0)
                    break;

                Resource selected = resources[auswahl - 1];

                Console.WriteLine($"Enter quantity ({selected.Unit}):");
                bool gültigMenge = double.TryParse(Console.ReadLine(), out double menge);

                if (!gültigMenge || menge <= 0)
                {
                    Console.WriteLine("Invalid quantity!");
                    continue;
                }

                calculation.AddResource(selected, menge);
                Console.WriteLine($"Added: {selected.Name} x {menge} = {selected.CalculateCost(menge):F2} EUR");
            }

            calculations.Add(calculation);
            calculation.ShowSummary();
        }

        public void ShowCalculations()
        {
            if (calculations.Count == 0)
            {
                Console.WriteLine("No calculations found!");
                return;
            }

            Console.WriteLine("=================================");
            Console.WriteLine("       Past Calculations         ");
            Console.WriteLine("=================================");

            foreach (Calculation c in calculations)
                c.ShowSummary();
        }

        public override void ShowProfile()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("       Customer Profile          ");
            Console.WriteLine("=================================");
            base.ShowProfile();
            Console.WriteLine($"Total Calculations: {calculations.Count}");
            Console.WriteLine("=================================");
        }
    }
}
