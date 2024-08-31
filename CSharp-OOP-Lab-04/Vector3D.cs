using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_OOP_Bai2
{
    internal class Vector3D : Vector
    {
        private int x;
        private int y;
        private int z;
        public Vector3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
        public override string ShowInfo()
        {
            return $"({x}, {y}, {z})";
        }
        public override Vector Sum(Vector v)
        {
            Vector3D result = new Vector3D(0, 0, 0);
            if (v is Vector3D)
            {
                Vector3D vector3D = (Vector3D)v;
                result = new Vector3D(X + vector3D.X, Y + vector3D.Y, Z + vector3D.Z);
            }
            return result;
        }
        public override bool Onth(Vector v)
        {
            bool check = false;
            if (v is Vector3D)
            {
                Vector3D vector3D = (Vector3D)v;
                int mul = X * vector3D.X + Y * vector3D.Y + Z * vector3D.Z;
                if (mul == 0)
                {
                    check = true;
                }
            }
            return check;
        }
    }
}
