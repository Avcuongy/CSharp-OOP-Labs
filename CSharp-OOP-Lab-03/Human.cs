using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_OOP_Bai1
{
    internal class Human
    {
        private string name;
        private string place_of_birth;
        private DateTime birthday;
        public Human(string name, string place_of_birth, DateTime birthday)
        {
            this.name = name;
            this.place_of_birth = place_of_birth;
            this.birthday = birthday;
        }

        public string Name { get => name; set => name = value; }
        public string Place_of_birth { get => place_of_birth; set => place_of_birth = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
    }
}
