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
        public int Cost { get => Cost; set => Cost = value; }
        public int Value { get => Value; set => Value = value; }
        public DateTime Start { get => Start; set => Start = value; }
        public TimeSpan Duration { get => Duration; set => Duration = value; }
        public int Fertilizer { get => Fertilizer; set => Fertilizer = value; }
        public int Water { get => Water; set => Water = value; }
        abstract public void Seed();
        abstract public void Harvest();
    }
}
