using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_05
{
    internal class Circle2D : ICircle
    {
        private float r;
        private Point2D center;
        public Circle2D(Point2D center, float r)
        {
            this.r = r;
            this.center = center;
        }

        public float R { get => R; set => R = value; }
        internal Point2D Center { get => center; set => center = value; }
        
        public float cal_area()
        {
            return (float)Math.PI * R * R;
        }
    }
}