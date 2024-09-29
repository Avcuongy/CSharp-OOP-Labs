using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;

namespace CSharp_OOP_Lab_10
{
    [XmlRoot("Student")]
    [Serializable]
    public class Student
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        public Student() { }

        public override string ToString()
        {
            return $"Student ID: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
