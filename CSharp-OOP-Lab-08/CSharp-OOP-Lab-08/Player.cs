using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_08
{
    internal class Player
    {
        private string username;
        private int rewared;
        public Player(string username, int rewared)
        {
            this.username = username;
            this.rewared = rewared;
        }
        public string Username { get => username; set => username = value; }
        public int Rewared { get => rewared; set => rewared = value; }
        public bool CheckUser(string username)
        {
            return this.username == username;
        }
    }
}
