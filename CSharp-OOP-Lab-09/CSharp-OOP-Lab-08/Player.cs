using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace CSharp_OOP_Lab_08
{
    [Serializable]
    internal class Player:ISerializable
    {
        private string username;
        private int reward;
        public string Username { get => username; set => username = value; }
        public int Reward { get => reward; set => reward = value; }
        public Player(string username, int reward)
        {
            this.username = username;
            this.reward = reward;
        }
        public bool CheckUser(string username)
        {
            return this.username == username;
        }
        public string ShowInfo()
        {
            return $"Username: {Username}\nReward:{Reward}";
        }
        public void AddReward(int profit)
        {
            Reward += profit;
        }
        public Player(SerializationInfo info, StreamingContext context)
        {
            Username = info.GetString("Username");
            Reward = info.GetInt32("Reward");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Username", Username);
            info.AddValue("Reward", Reward);
        }
    }
}
