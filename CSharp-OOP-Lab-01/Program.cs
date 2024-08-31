
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_OOP_Buoi2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student[] st = new Student[]
            {
                new Student("A", 2),
                new Student("B", 2.4f),
                new Student("E", 3),
                new Student("F", 2.3f),
                new Student("G", 4),
                new Student("D", 3),
                new Student("I", 2),
                new Student("H", 3.4f),
                new Student("J", 3.5f),
                new Student("C", 3.7f),
                new Student("Z",2.14f)
            };

            Student sortAndPrint = new Student("GGG", 0);

            sortAndPrint.Print(sortAndPrint.SortDesc(st));

            Console.ReadKey();
        }
    }
}
