using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AzureCostManager.Classes;

namespace AzureCostManager.Classes
{
    public class Customer : User
    {
        private List<Calculation> calculations = new List<Calculation>();

        public Customer(string username, string pin)
            : base(username, pin, "Customer")
        {
        }

        public void FullCalculation(List<Resource> resources)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       Full Calculation          ");
            Console.WriteLine("=================================");
            Console.WriteLine("Enter values for all resources:");

            Calculation calculation = new Calculation(Username);

            foreach (Resource r in resources)
            {
                Console.WriteLine($"\n{r.Name} ({r.Unit}) - {r.PricePerUnit:F2} EUR/{r.Unit}:");
                bool gültig = double.TryParse(Console.ReadLine(), out double menge);
                if (gültig && menge > 0)
                    calculation.AddResource(r, menge);
            }

            calculations.Add(calculation);
            Console.Clear();
            calculation.ShowSummary();
            Console.ReadKey();
        }

        public void IndividualCalculation(List<Resource> resources)
        {
            Console.Clear();
            Calculation calculation = new Calculation(Username);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("      Custom Calculation         ");
                Console.WriteLine("=================================");

                for (int i = 0; i < resources.Count; i++)
                    Console.WriteLine($"{i + 1}. {resources[i].Name} - {resources[i].PricePerUnit:F2} EUR/{resources[i].Unit}");

                Console.WriteLine("0. Finish & Show Summary");
                Console.WriteLine("Your choice:");

                bool gültig = int.TryParse(Console.ReadLine(), out int auswahl);

                if (auswahl == 0) break;

                if (!gültig || auswahl < 1 || auswahl > resources.Count)
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadKey();
                    continue;
                }

                Resource selected = resources[auswahl - 1];
                Console.WriteLine($"Enter {selected.Unit} for {selected.Name}:");
                bool gültigMenge = double.TryParse(Console.ReadLine(), out double menge);

                if (gültigMenge && menge > 0)
                {
                    calculation.AddResource(selected, menge);
                    Console.WriteLine($"Added: {selected.Name} = {selected.CalculateCost(menge):F2} EUR");
                    Console.ReadKey();
                }
            }

            calculations.Add(calculation);
            Console.Clear();
            calculation.ShowSummary();
            Console.ReadKey();
        }

        public void EditCalculation()
        {
            if (calculations.Count == 0)
            {
                Console.WriteLine("No calculations found!");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       Edit Calculation          ");
            Console.WriteLine("=================================");

            for (int i = 0; i < calculations.Count; i++)
                Console.WriteLine($"{i + 1}. Calculation from {calculations[i].Date:dd.MM.yyyy HH:mm}");

            Console.WriteLine("Select calculation:");
            bool gültig = int.TryParse(Console.ReadLine(), out int auswahl);

            if (!gültig || auswahl < 1 || auswahl > calculations.Count)
            {
                Console.WriteLine("Invalid input!");
                Console.ReadKey();
                return;
            }

            calculations[auswahl - 1].EditResource();
            Console.ReadKey();
        }

        public void ShowCalculations()
        {
            if (calculations.Count == 0)
            {
                Console.WriteLine("No calculations found!");
                return;
            }

            Console.Clear();
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
