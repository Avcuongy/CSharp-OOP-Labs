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
    internal class StudentList:ISerializable
    {
        private List<Student> students = new List<Student>();
        public List<Student> Students { get => students; set => students = value; }
        public StudentList() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Student", Students);
        }
        public StudentList(SerializationInfo info, StreamingContext context)
        {
            Students = (List<Student>)info.GetValue("Student", typeof(List<Student>));
        }
        public void Add(Student item)
        {
            Students.Add(item);
        }
    }
}
