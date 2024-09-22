using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_08
{
    internal class Wheat:Product
    {
        private int numFetilizer;
        private int numWater;
        public int NumFetilizer { get => numFetilizer; set => numFetilizer = value; }
        public int NumWater { get => numWater; set => numWater = value; }
        public Wheat()
        {
            Cost = 20;
            Value = 200;
            Fertilizer = 20;
            Water = 20;
            Duration = TimeSpan.FromSeconds(10);
        }
        public override string Seed()
        {
            Start = DateTime.Now;
            return $"Wheat has peen planted at {Start.ToShortTimeString()}";
        }
        public override int Harvest()
        {
            int totalCost = Cost + (numFetilizer*Fertilizer) + (numWater*Water);
            int profit = Value - totalCost;
            Console.WriteLine($"Wheat harvest => profit = {profit}");
            return profit;
        }
        public void Feed()
        {
            numFetilizer++;
            Console.WriteLine("Wheat has been fertilized");
        }
        public void ProvWater()
        {
            numWater++;
            Console.WriteLine("Wheat has been water");
        }
    }
}
