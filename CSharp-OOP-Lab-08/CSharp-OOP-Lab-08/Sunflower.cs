using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        public override void Seed()
        {
            Start = DateTime.Now;
            Console.WriteLine("Sunflower has peen planted");
        }
        public override void Harvest()
        {
            int totalCost = Cost + (numFetilizer * Fertilizer) + (numWater * Water);
            int profit = Value - totalCost;
            Console.WriteLine($"Sunflower harvest => profit = {profit}");
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
    }
}
