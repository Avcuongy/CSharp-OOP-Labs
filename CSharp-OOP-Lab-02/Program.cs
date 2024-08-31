using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2_OOP_Buoi2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 10);
            Vector v2 = new Vector(10, 20);
            Vector sum = v1.Add(v2), sub = v1.Sub(v2);
            float mul = v1.Mul(v2);
            bool onth = v1.Onth(v2);

            /*Console.WriteLine(v1.PrintVector());
            Console.WriteLine(sum.PrintVector());
            Console.WriteLine(sub.PrintVector());
            Console.WriteLine(mul);
            Console.WriteLine(onth);*/

            List<Vector> list = new List<Vector>()
            {
                new Vector(1, 20),
                new Vector(2, 19),
                new Vector(3, 18),
                new Vector(5, 100),
                new Vector(5, 16),
                new Vector(6, 15),
                new Vector(7, 14),
                new Vector(8, 13),
                new Vector(-10, 1),
                new Vector(-50,5),
            };

            Vector pro = v1;

            // Tổng các vector
            /*foreach (Vector v in list)
            {
                pro = pro.Add(v);
            }
            Console.WriteLine(pro.PrintVector());*/

            //Hiệu các vector
            /*foreach (Vector v in list)
            {
                pro = pro.Sub(v);
            }
            Console.WriteLine(pro.PrintVector());*/

            //Tổng Tích các vector
            /* float multi = 0;
            foreach (Vector v in list)
            {
                multi += pro.Mul(v);
            }
            Console.WriteLine(multi);*/

            //Các vector trực giao
            foreach (Vector v in list)
            {
                if (pro.Onth(v))
                    Console.WriteLine(v.PrintVector());
            }

            Console.ReadKey();
        }
    }
}