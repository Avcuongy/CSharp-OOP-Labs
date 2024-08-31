using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_OOP_Bai2
{
    internal class Program
    {
        // Method Main
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random rd = new Random();

           Vector[] arr = new Vector[]
            {
                new Vector2D(1, 0),
                new Vector2D(1, -1),
                new Vector2D(2, 7),
                new Vector2D(0, 3),
                new Vector2D(-7, 2),
                new Vector3D(0, 0,1),
                new Vector3D(5, 4,4),
                new Vector3D(0,0,-1),
                new Vector3D(2,2,2),
                new Vector3D(7,8,9),
                new Vector3D(-2,2,0)
            };

            // Tạo mảng 10 phần tử Vector ngẫu nhiên
            /*Vector[] arr = new Vector[10];
            for (int i = 0; i < arr.Length; i++)
            {
                if (rd.Next(2) == 0)
                {
                    arr[i] = new Vector2D(rd.Next(-10, 11), rd.Next(-10, 11));
                }
                else
                {
                    arr[i] = new Vector3D(rd.Next(-10, 11), rd.Next(-10, 11), rd.Next(-10, 11));
                }
            }*/

            // In các Vector
            foreach (Vector i in arr)
            {
                Console.Write("Vector :");
                Console.WriteLine(i.ShowInfo());
            }

            Console.WriteLine("-------------------------------------------");

            // In Tổng Các Vector 2D và 3D
            PrintSumVector(arr);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-------------------------------------------");

            // Xử lí và in trực giao vector 2D và 3D
            PrintOnthList(arr);

            Console.ReadKey();
        }
        // Method In Tổng Vector 2D và 3D
        static void PrintSumVector(Vector[] arr)
        {
            Vector2D v2d = new Vector2D(0, 0);
            Vector3D v3d = new Vector3D(0, 0, 0);
            foreach (Vector j in arr)
            {
                if (j is Vector2D)
                {
                    v2d = (Vector2D)v2d.Sum(j);
                }
                else if (j is Vector3D)
                {
                    v3d = (Vector3D)v3d.Sum(j);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Sum Vector 2D = {v2d.ShowInfo()}");
            Console.WriteLine($"Sum Vector 3D = {v3d.ShowInfo()}");
        }
        // Method Xử lí và in các cặp vector trực giao
        static void PrintOnthList(Vector[] arr)
        {
            List<Vector2D> list2D = new List<Vector2D>(); // Chứa Vector 2D
            List<Vector3D> list3D = new List<Vector3D>(); // Chứa Vector 3D
            foreach (Vector k in arr)
            {
                if (k is Vector2D)
                {
                    list2D.Add((Vector2D)k);
                }
                else if (k is Vector3D)
                {
                    list3D.Add((Vector3D)k);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Các cặp trực giao vector 2D: ");
            for (int i = 0; i < list2D.Count - 1; i++)
            {
                Vector2D v = list2D[i];
                for (int j = i + 1; j < list2D.Count; j++)
                {
                    if (v.Onth(list2D[j]))
                    {
                        Console.WriteLine($"{v.ShowInfo()} và {list2D[j].ShowInfo()}");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Các cặp trực giao vector 3D: ");
            for (int i = 0; i < list3D.Count - 1; i++)
            {
                Vector3D v = list3D[i];
                for (int j = i + 1; j < list3D.Count; j++)
                {
                    if (v.Onth(list3D[j]))
                    {
                        Console.WriteLine($"{v.ShowInfo()} và {list3D[j].ShowInfo()}");
                    }
                }
            }
        }
    }
}
