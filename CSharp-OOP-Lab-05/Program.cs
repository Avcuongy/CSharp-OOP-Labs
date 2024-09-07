using System;
using System.Collections.Generic;
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Khoảng cách Point:\n");
            Console.ForegroundColor = ConsoleColor.White;

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
            Console.WriteLine("+------------+------------+------------+");
            Console.WriteLine($"|{"Point2D",-12}|{"Point2D",-12}|{"Distance",-12}|");
            Console.WriteLine("+------------+------------+------------+");
            for (int i = 0; i < point2D.Count - 1; i++)
            {
                for (int j = i + 1; j < point2D.Count; j++)
                {
                    Console.WriteLine($"|{point2D[i].showinfo(),-12}|{point2D[j].showinfo(),-12}|{point2D[i].cal_dist(point2D[j]),-12}|");
                }
            }
            Console.WriteLine("+------------+------------+------------+\n");

            // Tính khoảng cách giữa các điểm 3D
            Console.WriteLine("+------------+------------+------------+");
            Console.WriteLine($"|{"Point3D",-12}|{"Point3D",-12}|{"Distance",-12}|");
            Console.WriteLine("+------------+------------+------------+");
            for (int i = 0; i < point3D.Count - 1; i++)
            {
                for (int j = i + 1; j < point3D.Count; j++)
                {
                    Console.WriteLine($"|{point3D[i].showinfo(),-12}|{point3D[j].showinfo(),-12}|{point3D[i].cal_dist(point3D[j]),-12}|");
                }
            }
            Console.WriteLine("+------------+------------+------------+");
        }
        // Method diện tích từng cặp ICircle
        static void PrintCalArea(ICircle[] arrCircle)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Diện tích:\n");
            Console.ForegroundColor = ConsoleColor.White;
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

            Console.WriteLine("+--------------------+------------+");
            Console.WriteLine($"|{"Circle2D",-20}|{"Diện tích",-12}|");
            Console.WriteLine("+--------------------+------------+");
            foreach (Circle2D i in circle2D)
            {
                Console.WriteLine($"|{i.showinfo(),-20}|{i.cal_area(),-12}|");
            }
            Console.WriteLine("+--------------------+------------+\n");

            Console.WriteLine("+--------------------+------------+");
            Console.WriteLine($"|{"Circle3D",-20}|{"Diện tích",-12}|");
            Console.WriteLine("+--------------------+------------+");
            foreach (Circle3D i in circle3D)
            {
                Console.WriteLine($"|{i.showinfo(),-20}|{i.cal_area(),-12}|");
            }
            Console.WriteLine("+--------------------+------------+");
        }
        // Method vị trí tương đối
        static void PrintPositionPoint()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vị trí tương đối:\n");
            Console.ForegroundColor = ConsoleColor.White;
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

            //20-12-12
            Console.WriteLine("+--------------------+------------+------------+");
            Console.WriteLine($"|{"Circle2D",-20}|{"Point2D",-12}|{"VTTT",-12}|");
            Console.WriteLine("+--------------------+------------+------------+");
            foreach (Circle2D circle in circle2D)
            {
                foreach (Point2D point in point2D)
                {
                    if (circle.Center.cal_dist(point) > circle.R)
                    {
                        Console.WriteLine($"|{circle.showinfo(),-20}|{point.showinfo(),-12}|{"Nằm ngoài",-12}|");
                    }
                    else if (circle.Center.cal_dist(point) < circle.R)
                    {
                        Console.WriteLine($"|{circle.showinfo(),-20}|{point.showinfo(),-12}|{"Nằm trong",-12}|");
                    }
                    else
                    {
                        Console.WriteLine($"|{circle.showinfo(),-20}|{point.showinfo(),-12}|{"Nằm trên",-12}|");
                    }
                }
            }
            Console.WriteLine("+--------------------+------------+------------+\n");

            Console.WriteLine("+--------------------+------------+------------+");
            Console.WriteLine($"|{"Circle3D",-20}|{"Point3D",-12}|{"VTTT",-12}|");
            Console.WriteLine("+--------------------+------------+------------+");
            foreach (Circle3D circle in circle3D)
            {
                foreach (Point3D point in point3D)
                {
                    if (circle.Center.cal_dist(point) > circle.R)
                    {
                        Console.WriteLine($"|{circle.showinfo(),-20}|{point.showinfo(),-12}|{"Nằm ngoài",-12}|");
                    }
                    else if (circle.Center.cal_dist(point) < circle.R)
                    {
                        Console.WriteLine($"|{circle.showinfo(),-20}|{point.showinfo(),-12}|{"Nằm trong",-12}|");
                    }
                    else
                    {
                        Console.WriteLine($"|{circle.showinfo(),-20}|{point.showinfo(),-12}|{"Nằm trên",-12}|");
                    }
                }
            }
            Console.WriteLine("+--------------------+------------+------------+");
        }
        // Method in ra toàn bộ kết quả
        static void PrintAllResults()
        {
            PrintCalArea(arrCircle);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n---------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            PrintDistPoint(arrPoint);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n---------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            PrintPositionPoint();
        }
    }
}