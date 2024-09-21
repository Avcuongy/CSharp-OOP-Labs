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
        }
        public override void Seed()
        {
            Start = DateTime.Now;
            Console.WriteLine("Tomato has peen planted");
        }
        public override void Harvest()
        {
            int totalCost = Cost + (numFetilizer * Fertilizer) + (numWater * Water);
            int profit = Value - totalCost;
            Console.WriteLine($"Tomato harvest => profit = {profit}");
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
