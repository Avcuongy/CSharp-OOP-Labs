using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_08
{
    internal class Tomato:Product
    {
        private int numFetilizer;
        private int numWater;
        public int NumFetilizer { get => numFetilizer; set => numFetilizer = value; }
        public int NumWater { get => numWater; set => numWater = value; }
        public Tomato()
        {
            Cost = 30;
            Value = 300;
            Fertilizer = 30;
            Water = 30;
            Duration = TimeSpan.FromSeconds(20);
        }
        public override string Seed()
        {
            Start = DateTime.Now;
            return $"Tomato has peen planted at {Start.ToShortTimeString()}";
        }
        public override int Harvest()
        {
            int totalCost = Cost + (numFetilizer * Fertilizer) + (numWater * Water);
            int profit = Value - totalCost;
            Console.WriteLine($"Tomato harvest => profit = {profit}");
            return profit;
        }
        public void Feed()
        {
            numFetilizer++;
            Console.WriteLine("Tomato has been fertilized");
        }
        public void ProvWater()
        {
            numWater++;
            Console.WriteLine("Tomato has been water");
        }
    }
}
