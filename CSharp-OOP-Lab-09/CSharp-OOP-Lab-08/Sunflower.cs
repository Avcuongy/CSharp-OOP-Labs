using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace CSharp_OOP_Lab_08
{
    internal class Sunflower:Product
    {
        private int numFetilizer;
        private int numWater;
        public int NumFetilizer { get => numFetilizer; set => numFetilizer = value; }
        public int NumWater { get => numWater; set => numWater = value; }
        public Sunflower()
        {
            Cost = 50;
            Value = 500;
            Fertilizer = 50;
            Water = 50;
            Duration = TimeSpan.FromSeconds(10);
        }
        public override string Seed()
        {
            Start = DateTime.Now;
            return $"Sunflower has peen planted at {Start.ToShortTimeString()}";
        }
        public override int Harvest()
        {
            int totalCost = Cost + (numFetilizer * Fertilizer) + (numWater * Water);
            int profit = Value - totalCost;
            Console.WriteLine($"Sunflower harvest => profit = {profit}");
            return profit;
        }
        public void Feed()
        {
            numFetilizer++;
            Console.WriteLine("Sunflower has been fertilized");
        }
        public void ProvWater()
        {
            numWater++;
            Console.WriteLine("Sunflower has been water");
        }
        public bool IsWater()
        {
            return numWater == 1;
        }
        public bool IsFertilized()
        {
            return numFetilizer == 1;
        }
    }
}
