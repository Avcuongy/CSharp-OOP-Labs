using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;

namespace CSharp_OOP_Lab_10
{
    [Serializable]
    internal class Student:ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Student() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id); info.AddValue("Name", Name); info.AddValue("Age", Age);
        }
        public Student(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetInt32("Id"); Name = info.GetString("Name"); Age = info.GetInt32("Age");
        }
        public override string ToString()
        {
            return $"Student ID: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
