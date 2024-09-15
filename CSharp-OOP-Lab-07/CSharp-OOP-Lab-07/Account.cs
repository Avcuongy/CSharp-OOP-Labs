using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_07
{
    internal class Account
    {
        private string username;
        private string numberphone;
        private decimal balance;
        public Account(string Username, string numberphone, decimal balance)
        {
            this.username = Username;
            this.numberphone = numberphone;
            this.balance = balance;
        }
        public string Username { get => username; set => username = value; }
        public string Numberphone { get => numberphone; set => numberphone = value; }
        public decimal Balance { get => balance; set => balance = value; }
        public override string ToString()
        {
            return $"Name: {Username}\nNumber Phone: {Numberphone}\nBalance: {Balance}";
        }
    }
}
