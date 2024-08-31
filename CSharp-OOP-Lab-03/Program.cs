using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_OOP_Bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] prototype = new Student[]
            {
                new Student("AAAAA","DONG NAI",new DateTime(2005,1,1),"M10",4),
                new Student("BBBBB","TP HCM",new DateTime(2005,10,23),"M20",2.5f),
                new Student("CCCCC","THAI BINH",new DateTime(2005,11,11),"M30",3.4f),
                new Student("DDDDD","TAY NINH",new DateTime(2005,4,9),"M40",3.1f),
                new Student("EEEEE","CAN THO",new DateTime(2005,12,4),"M50",3.7f),
            };
            Student fun = new Student("0", "0", new DateTime(2005, 12, 4), "M60", 2.6f);
            fun.Print(fun.SortDesc(prototype));
            Console.ReadKey();
        }
    }
}
