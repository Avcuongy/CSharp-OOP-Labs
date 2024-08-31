using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_05
{
    internal class Circle3D : ICircle
    {
        private float r;
        private Point3D center;
        public Circle3D(Point3D center, float r)
        {
            this.r = r;
            this.center = center;
        }
        public float R { get => r; set => r = value; }
        internal Point3D Center { get => center; set => center = value; }
        public float cal_area()
        {
            return (float)Math.PI * R * R;
        }
    }
}
