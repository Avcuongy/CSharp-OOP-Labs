using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_05
{
    internal class Point3D : IPoint
    {
        private float x, y, z;
        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }

        public float cal_dist(IPoint other)
        {
            float result = 0;
            if (other is Point3D ot)
            {
                result = (float)Math.Sqrt(Math.Pow(ot.X - X, 2) + Math.Pow(ot.Y - Y, 2) + Math.Pow(ot.Z - Z, 2));
            }
            return result;
        }
        public string showinfo()
        {
            return $"({X},{Y},{Z})";
        }
    }
}