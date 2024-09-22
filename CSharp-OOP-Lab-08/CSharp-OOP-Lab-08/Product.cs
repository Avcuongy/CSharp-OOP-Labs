using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_08
{
    abstract class Product
    {
        private int cost;
        private int value;
        private DateTime start;
        private TimeSpan duration;
        private int fertilizer;
        private int water;
        public int Cost { get => cost; set => cost = value; }
        public int Value { get => value; set => this.value = value; }
        public DateTime Start { get => start; set => start = value; }
        public TimeSpan Duration { get => duration; set => duration = value; }
        public int Fertilizer { get => fertilizer; set => fertilizer = value; }
        public int Water { get => water; set => water = value; }
        abstract public string Seed();
        abstract public int Harvest();
    }
}
