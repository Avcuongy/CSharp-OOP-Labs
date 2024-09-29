using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;
using System.Threading;

namespace CSharp_OOP_Lab_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentList studentList = new StudentList();
            studentList.Add(new Student() { Id = 1, Name = "Nam", Age = 20 });
            studentList.Add(new Student() { Id = 2, Name = "Binh", Age = 21 });
            studentList.Add(new Student() { Id = 3, Name = "Minh", Age = 22 });

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(StudentList));

            using (FileStream fileStream = new FileStream("DataStudent.dat", FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, studentList);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Serialized XML written to file DataStudent.dat");
            Console.ForegroundColor = ConsoleColor.White;

            StudentList deserializedStudentList;
            using (FileStream fileStream = new FileStream("DataStudent.dat", FileMode.Open))
            {
                deserializedStudentList = (StudentList)xmlSerializer.Deserialize(fileStream);
            }

            foreach (Student student in deserializedStudentList.Students)
            {
                Console.WriteLine(student);
            }

            deserializedStudentList.Add(new Student() { Id = 4, Name = "Lan", Age = 23 });
            deserializedStudentList.Add(new Student() { Id = 5, Name = "Hoa", Age = 24 });

            using (FileStream fileStream = new FileStream("DataStudent.dat", FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, deserializedStudentList);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUpdated XML written to file DataStudent.xml");
            Console.ForegroundColor = ConsoleColor.White;

            using (FileStream fileStream = new FileStream("DataStudent.dat", FileMode.Open))
            {
                deserializedStudentList = (StudentList)xmlSerializer.Deserialize(fileStream);
            }

            foreach (Student student in deserializedStudentList.Students)
            {
                Console.WriteLine(student);
            }

            Console.ReadKey();
        }
    }
}
