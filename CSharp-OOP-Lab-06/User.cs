using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_06
{
    public class User
    {
        private string name;
        private byte idUser;

        public User(string name, byte idUser)
        {
            this.name = name;
            this.idUser = idUser;
        }
        public string Name { get => name; set => name = value; }
        public byte IdUser { get => idUser; set => idUser = value; }
        public override string ToString()
        {
            return $"User(ID: {idUser}, Name: {name})";
        }
    }
}
