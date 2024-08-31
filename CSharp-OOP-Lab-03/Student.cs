using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_OOP_Bai1
{
    class Student : Human
    {
        private string id;
        private float gpa;
        public Student(string name, string place_of_birth, DateTime birthday, string id, float gpa)
            : base(name, place_of_birth, birthday)
        {
            this.id = id;
            this.gpa = gpa;
        }
        public string Id { get => id; set => id = value; }
        public float Gpa { get => gpa; set => gpa = value; }
        public Student[] SortDesc(Student[] st)
        {
            for (int i = 0; i < st.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < st.Length; j++)
                {
                    if (st[j].Gpa > st[maxIndex].Gpa)
                    {
                        maxIndex = j;
                    }    
                }
                Student temp = st[i];
                st[i] = st[maxIndex];
                st[maxIndex] = temp;
            }            
            return st;
        }
        // Name - Place - Date - ID - gpa
        public void Print(Student[] st)
        {
            //9-17-15-5-5
            Console.WriteLine("+---------+-----------------+---------------+-----+-----+");
            Console.WriteLine($"|{"Name",-9}|{"Place Of Date",-17}|{"Date",-15}|{"ID",-5}|{"GPA",-5}|");
            Console.WriteLine("+---------+-----------------+---------------+-----+-----+");
            foreach (Student s in st)
            {
                Console.WriteLine($"|{s.Name,-9}|{s.Place_of_birth,-17}|{s.Birthday.ToShortDateString(),-15}|{s.Id,-5}|{s.Gpa,-5}|");
            }
            Console.WriteLine("+---------+-----------------+---------------+-----+-----+");
        }
    }
}
