﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_08
{
    internal class Player
    {
        private string username;
        private int reward;
        public Player(string username, int rewared)
        {
            this.username = username;
            this.reward = rewared;
        }
        public string Username { get => username; set => username = value; }
        public int Reward { get => reward; set => reward = value; }
        public bool CheckUser(string username)
        {
            return this.username == username;
        }
        public void ShowInfo(string username)
        {
            Console.WriteLine($"Username: {Username}\nReward:{Reward}"); 
        }
        public void AddReward(int profit)
        {
            Reward += profit;
        }
    }
}
