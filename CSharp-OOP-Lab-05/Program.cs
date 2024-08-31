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
            for (int i = 0; i < point2D.Count - 1; i++)
            {
                for (int j = i+1; j < point2D.Count; j++)
                {
                    
                }    
            }
            Console.WriteLine("----------------------------------------------");
        }
    }
}
