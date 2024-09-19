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
        public override void Seed()
        {

        }
        public override void Harvest()
        {

        }
        public void Feed()
        {

        }
        public void ProvWater()
        {

        }
    }
}
