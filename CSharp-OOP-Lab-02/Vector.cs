using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2_OOP_Buoi2
{
    internal class Vector
    {
        private float x;
        private float y;
        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public string PrintVector()
        {
            return $"Vector: ({x}, {y})";
        }
        public Vector Add(Vector v0)
        {
            return new Vector(X + v0.X, Y + v0.Y);
        }
        public Vector Sub(Vector v0)
        {
            return new Vector(X - v0.X, Y - v0.Y);
        }
        public float Mul(Vector v0)
        {
            return X * v0.X + Y * v0.Y;
        }
        public bool Onth(Vector v0)
        {
            return Mul(v0) == 0 ? true : false;
        }
    }
}