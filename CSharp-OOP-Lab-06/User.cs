using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_06
{
    public class User : ICloneable
    {
        private string name;
        private string idUser;
        public User(string name, string idUser)
        {
            this.name = name;
            this.IdUser = idUser;
        }
        public object Clone()
        {
            return new User(name, idUser);
        }
        public string Name { get => name; set => name = value; }
        public string IdUser { get => idUser; set => idUser = value; }
        public override string ToString()
        {
            return $"User(Name: {name}, ID: {IdUser})";
        }
    }
}
