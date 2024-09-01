using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_05
{
    internal class Program
    {
        // Hai mảng IPoint và ICircle
        static IPoint[] arrPoint = new IPoint[5];
        static ICircle[] arrCircle = new ICircle[5];
        // Hàm chính
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Khởi tạo 2 mảng IPoint và ICicle ngẫu nhiên
            Random rd = new Random();
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
                    arrCircle[i] = new Circle2D(new Point2D(rd.Next(-5, 6), rd.Next(-5, 6)), rd.Next(1, 11));
                }
                else
                {
                    arrCircle[i] = new Circle3D(new Point3D(rd.Next(-5, 6), rd.Next(-5, 6), rd.Next(-5, 6)), rd.Next(1, 11));
                }
            }

            // Thực thi
            PrintAllResults();
            Console.ReadKey();
        }
        // Method khoảng cách cửa từng cặp Point ra
        static void PrintDistPoint(IPoint[] arrPoint)
        {
            List<Point2D> point2D = new List<Point2D>();
            List<Point3D> point3D = new List<Point3D>();
            foreach (IPoint point in arrPoint)
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
            for (int i = 0; i < point2D.Count - 1; i++)
            {
                for (int j = i + 1; j < point2D.Count; j++)
                {
                    Console.WriteLine($"{point2D[i].showinfo()} và {point2D[j].showinfo()} => dist = {point2D[i].cal_dist(point2D[j])}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Tính khoảng cách giữa các điểm 3D
            for (int i = 0; i < point3D.Count - 1; i++)
            {
                for (int j = i + 1; j < point3D.Count; j++)
                {
                    Console.WriteLine($"{point3D[i].showinfo()} và {point3D[j].showinfo()} => dist = {point3D[i].cal_dist(point3D[j])}");
                }
            }
        }
        // Method diện tích từng cặp ICircle
        static void PrintCalArea(ICircle[] arrCircle)
        {
            List<Circle2D> circle2D = new List<Circle2D>();
            List<Circle3D> circle3D = new List<Circle3D>();
            foreach (ICircle circle in arrCircle)
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
        // Method vị trí tương đối
        static void PrintPositionPoint()
        {
            // Tách thành các kiểu riêng biệt
            List<Circle2D> circle2D = new List<Circle2D>();
            List<Circle3D> circle3D = new List<Circle3D>();
            List<Point2D> point2D = new List<Point2D>();
            List<Point3D> point3D = new List<Point3D>();
            foreach (ICircle circle in arrCircle)
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
            foreach (IPoint point in arrPoint)
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

            // Point2D và Circle2D
            foreach (Circle2D circle in circle2D)
            {
                foreach (Point2D point in point2D)
                {
                    if (circle.Center.cal_dist(point) > circle.R)
                    {
                        Console.WriteLine($"Point {point.showinfo()} nằm ngoài Circle {circle.showinfo()}");
                    }
                    else if (circle.Center.cal_dist(point) < circle.R)
                    {
                        Console.WriteLine($"Point {point.showinfo()} nằm trong Circle {circle.showinfo()}");
                    }
                    else
                    {
                        Console.WriteLine($"Point {point.showinfo()} nằm trên Circle {circle.showinfo()}");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Point3D và Circle3D
            foreach (Circle3D circle in circle3D)
            {
                foreach (Point3D point in point3D)
                {
                    if (circle.Center.cal_dist(point) > circle.R)
                    {
                        Console.WriteLine($"Point {point.showinfo()} nằm ngoài Circle {circle.showinfo()}");
                    }
                    else if (circle.Center.cal_dist(point) < circle.R)
                    {
                        Console.WriteLine($"Point {point.showinfo()} nằm trong Circle {circle.showinfo()}");
                    }
                    else
                    {
                        Console.WriteLine($"Point {point.showinfo()} nằm trên Circle {circle.showinfo()}");
                    }
                }
            }

        }
        // Method in ra toàn bộ kết quả
        static void PrintAllResults()
        {
            PrintCalArea(arrCircle);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            PrintDistPoint(arrPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            PrintPositionPoint();
        }
    }
}