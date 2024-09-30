using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace CSharp_OOP_Lab_08
{
    [Serializable]
    abstract class Product : ISerializable
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
        public Product() { }
        public Product(SerializationInfo info, StreamingContext context)
        {
            Cost = info.GetInt32("Cost");
            Value = info.GetInt32("Value");
            Start = info.GetDateTime("Start");
            Duration = (TimeSpan)info.GetValue("Duration", typeof(TimeSpan));
            Fertilizer = info.GetInt32("Fertilizer");
            Water = info.GetInt32("Water");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Cost", Cost);
            info.AddValue("Value", Value);
            info.AddValue("Value", Start);
            info.AddValue("Duration", Duration);
            info.AddValue("Fertilizer", Fertilizer);
            info.AddValue("Water", Water);
        }
    }
}