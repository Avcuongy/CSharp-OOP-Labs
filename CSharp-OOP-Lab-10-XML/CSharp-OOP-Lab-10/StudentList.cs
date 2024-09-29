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
    [XmlRoot("StudentList")]
    [Serializable]
    public class StudentList
    {
        [XmlArray("Students")]
        [XmlArrayItem("Student")]
        private List<Student> students = new List<Student>();

        public List<Student> Students { get => students; set => students = value; }

        public StudentList() { }

        public void Add(Student item)
        {
            Students.Add(item);
        }
    }
}
