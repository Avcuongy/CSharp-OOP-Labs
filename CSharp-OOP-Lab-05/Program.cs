using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Khởi tạo 2 mảng IPoint và ICicle ngẫu nhiên
            Random rd = new Random();
            IPoint[] arrPoint = new IPoint[5];
            ICircle[] arrCircle = new ICircle[5];
            //IPoint
            for (int i = 0; i < arrPoint.Length; i++)
            {
                if (rd.Next(2) == 0)
                {
                    arrPoint[i] = new Point2D(rd.Next(-5, 6), rd.Next(-5, 6));
                }
                else
                {
                    arrPoint[i] = new Point3D(rd.Next(-5, 6), rd.Next(-5, 6), rd.Next(-5, 6));
                }
            }
            //Icircle
            for (int i = 0; i < arrCircle.Length; i++)
            {
                if (rd.Next(2) == 0)
                {
                    arrCircle[i] = new Circle2D(new Point2D(rd.Next(-5, 6), rd.Next(-5, 6)), rd.Next(1,11));
                }
                else
                {
                    arrCircle[i] = new Circle3D(new Point3D(rd.Next(-5, 6), rd.Next(-5, 6), rd.Next(-5, 6)), rd.Next(1,11));
                }
            }

            // Thực thi
            PrintCalArea(arrCircle);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---------------------------------------------------------\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            PrintDistPoint(arrPoint);

            Console.ReadKey();           
        }
        // Method in Khoảng cách cửa từng cặp Point ra
        static void PrintDistPoint(IPoint[] pt)
        {
            List<Point2D> point2D = new List<Point2D>();
            List<Point3D> point3D = new List<Point3D>();
            foreach (IPoint point in pt)
            {
                if (point is Point2D)
                {
                    point2D.Add((Point2D)point);
                }
                else
                {
                    point3D.Add((Point3D)point);
                }
            }
            // Tính khoảng cách giữa các điểm 2D
            for (int i = 0; i < point2D.Count-1; i++)
            {
                for (int j = i + 1; j < point2D.Count; j++)
                {
                    Console.WriteLine($"{point2D[i].showinfo()} và {point2D[j].showinfo()} dist = {point2D[i].cal_dist(point2D[j])}");
                }
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---------------------------------------------------------\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Tính khoảng cách giữa các điểm 3D
            for (int i = 0; i < point3D.Count - 1; i++)
            {
                for (int j = i + 1; j < point3D.Count; j++)
                {
                    Console.WriteLine($"{point3D[i].showinfo()} và {point3D[j].showinfo()} dist = {point3D[i].cal_dist(point3D[j])}");
                }
            }
        }
        // Method in diện tích từng cặp ICircle
        static void PrintCalArea(ICircle[] pc)
        {
            List<Circle2D> circle2D = new List<Circle2D>();
            List<Circle3D> circle3D = new List<Circle3D>();
            foreach (ICircle circle in pc)
            {
                if (circle is Circle2D)
                {
                    circle2D.Add((Circle2D)circle);
                }
                else
                {
                    circle3D.Add((Circle3D)circle);
                }
            }
            foreach (Circle2D i in circle2D)
            {
                Console.WriteLine($"Circle2D {i.showinfo()} có diện tích = {i.cal_area()}");
            }
            foreach (Circle3D i in circle3D)
            {
                Console.WriteLine($"Circle3D {i.showinfo()} có diện tích = {i.cal_area()}");
            }
        }
    }
}
