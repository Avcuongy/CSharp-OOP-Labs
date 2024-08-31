using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_OOP_Bai2
{
    internal class Vector2D : Vector
    {
        private int x;
        private int y;
        public Vector2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public override string ShowInfo()
        {
            return $"({x}, {y})";
        }
        public override Vector Sum(Vector v)
        {
            Vector2D result = new Vector2D(0, 0);
            if (v is Vector2D)
            {
                Vector2D vector2D = (Vector2D)v;
                result = new Vector2D(X + vector2D.X, Y + vector2D.Y);
            }
            return result;
        }
        public override bool Onth(Vector v)
        {
            bool check = false;
            if (v is Vector2D)
            {
                Vector2D vector2D = (Vector2D)v;
                int mul = vector2D.X*X+vector2D.Y*Y;
                if (mul == 0)
                {
                    check = true;
                }    
            }
            return check;
        }
    }
}
