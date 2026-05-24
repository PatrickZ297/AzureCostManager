using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCostManager.Classes
{
    public class Resource
    {
        private string name;
        private string unit;
        private double pricePerUnit;

        public string Name => name;
        public string Unit => unit;
        public double PricePerUnit => pricePerUnit;

        public Resource(string name, string unit, double pricePerUnit)
        {
            this.name = name;
            this.unit = unit;
            this.pricePerUnit = pricePerUnit;
        }

        public double CalculateCost(double quantity)
        {
            return pricePerUnit * quantity;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"{name} - {pricePerUnit:F2} EUR/{unit}");
        }
    }
}
