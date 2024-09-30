using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading;

namespace CSharp_OOP_Lab_10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = "DataStudent.dat";
            StudentList studentList;

            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                studentList = JsonSerializer.Deserialize<StudentList>(fileContent);
            }
            else
            {
                studentList = new StudentList();
                studentList.Add(new Student() { Id = 1, Name = "Nam", Age = 20 });
                studentList.Add(new Student() { Id = 2, Name = "Binh", Age = 21 });
                studentList.Add(new Student() { Id = 3, Name = "Minh", Age = 22 });
            }


            string json = JsonSerializer.Serialize(studentList, new JsonSerializerOptions { WriteIndented = true });

            /*Console.WriteLine("Serialized JSON: ");
            Console.WriteLine(json + "\n");*/

            StudentList deserializedStudentList = JsonSerializer.Deserialize<StudentList>(json);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deserialized Student List: ");
            Console.ForegroundColor= ConsoleColor.White;
            foreach (Student student in deserializedStudentList.Students)
            {
                Console.WriteLine(student);
            }

            //deserializedStudentList.Add(new Student() { Id = 4, Name = "Lan", Age = 23 });
            //deserializedStudentList.Add(new Student() { Id = 5, Name = "Hoa", Age = 24 });
            //deserializedStudentList.Add(new Student() { Id = 6, Name = "Nigga", Age = 25 });


            string updatedJson = JsonSerializer.Serialize(deserializedStudentList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("DataStudent.dat", updatedJson);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUpdated JSON written to file data.dat");
            Console.ForegroundColor = ConsoleColor.White;

            string finaljson = File.ReadAllText("DataStudent.dat");
            StudentList finalStudentList = JsonSerializer.Deserialize<StudentList>(finaljson);

            foreach (Student student in finalStudentList.Students)
            {
                Console.WriteLine(student);
            }
            Console.ReadKey();
        }
    }
}
