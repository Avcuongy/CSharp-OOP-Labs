using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_05
{
    internal class Point2D : IPoint
    {
        private float x, y;
        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float cal_dist(IPoint other)
        {
            float result = 0;
            if (other is Point2D ot)
            {
                result = (float)Math.Sqrt(Math.Pow(ot.X - X, 2) + Math.Pow(ot.Y - Y, 2));
            }
            return result;
        }
        public string showinfo()
        {
            return $"({X},{Y})";
        }
    }
}