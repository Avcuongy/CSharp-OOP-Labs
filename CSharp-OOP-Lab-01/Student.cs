
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_OOP_Buoi2
{
    internal class Student
    {
        private string name;
        private float gpa;
        public Student(string name, float gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }
        public string Name { get => name; set => name = value; }
        public float Gpa { get => gpa; set => gpa = value; }
        public Student[] SortDesc(Student[] st)
        {
            for (int i = 0; i < st.Length - 1; i++)
            {
                for (int j = i + 1; j < st.Length; j++)
                {
                    if (st[i].Gpa < st[j].Gpa)
                    {
                        Student temp = st[i];
                        st[i] = st[j];
                        st[j] = temp;
                    }
                }
            }
            return st;
        }
        public void Print(Student[] st)
        {
            //6-20-6
            Console.WriteLine("+------+--------------------+------+");
            Console.WriteLine($"|{"STT",-6}|{"Name",-20}|{"GPA",-6}|");
            Console.WriteLine("+------+--------------------+------+");
            for (int i = 0; i < st.Length; i++)
            {
                Console.WriteLine($"|{i + 1,-6}|{st[i].Name,-20}|{st[i].Gpa,-6}|");
            }
            Console.WriteLine("+------+--------------------+------+");
        }
    }
}
