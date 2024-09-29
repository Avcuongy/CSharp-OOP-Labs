using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace CSharp_OOP_Lab_08
{
    internal class Program
    {
        public static void SerializeData(List<Player> users, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    formatter.Serialize(fs, users);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                    throw;
                }
            }
        }
        public static List<Player> DeserializeData(string filePath)
        {
            List<Player> users = null;
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        users = (List<Player>)formatter.Deserialize(fs);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to deserialize. Reason: " + ex.Message);
                        throw;
                    }
                }
            }
            return users ?? new List<Player>();
        }
        static void Main(string[] args)
        {

            string filePath = "playersData.dat";

            // Deserialize dữ liệu từ file nếu có
            List<Player> Users = DeserializeData(filePath);

            Console.OutputEncoding = Encoding.UTF8;

            List<string> selectedProductsChoice = new List<string>();

            List<Product> Products = new List<Product>();

            if (Users == null || Users.Count == 0)
            {
                Users = new List<Player>()
                {
                    new Player("A", 2000),
                    new Player("B", 3000),
                    new Player("C", 4000)
                };
            }

        Login:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Menu Login\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Username: ");
            string username = Console.ReadLine();

            bool checkUser = false;
            Player player = null;

            try
            {
                foreach (Player p in Users)
                {
                    if (p.CheckUser(username))
                    {
                        checkUser = true;
                        player = p;
                    }
                }
                if (!checkUser)
                {
                    Console.Clear();
                    Console.WriteLine("Username wrong! Enter Your Username Again !");
                    Thread.Sleep(500);
                    goto Login;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Welcome {username} Back To Your Farm !");
                    Thread.Sleep(500);
                }

            MainMenu:

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                player.ShowInfo(username);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Main Menu:\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Seed");
                Console.WriteLine("2. Exit\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Enter your choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        {

                        MainSeed:

                            Console.Clear();
                            Console.WriteLine("Choose Seed:\n");
                            Console.WriteLine("1. Wheat\n2. Tomato\n3. Sunflower\n4. Back\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Your Choose: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string seedChoice = Console.ReadLine();

                            Product selectedProduct = null;

                            switch (seedChoice)
                            {
                                case "1":
                                    selectedProduct = new Wheat();
                                    break;
                                case "2":
                                    selectedProduct = new Tomato();
                                    break;
                                case "3":
                                    selectedProduct = new Sunflower();
                                    break;
                                case "4":
                                    goto MainMenu;
                            }

                            if (selectedProduct != null)
                            {
                                if (player.Reward < selectedProduct.Cost)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Not enough reward to plant this seed.(Back After 0.5s)");
                                    Thread.Sleep(800);
                                    goto MainSeed;
                                }

                                selectedProductsChoice.Add(selectedProduct.Seed());

                                Products.Add(selectedProduct);

                            Back:

                                Console.Clear();

                                foreach (string choice in selectedProductsChoice)
                                {
                                    Console.WriteLine(choice);
                                }

                                Console.WriteLine();
                                Console.WriteLine("Choose method:\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("1. Feed\n2. ProvWater\n3. Harvest:\n4. Back\n");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter your choose: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                string pick = Console.ReadLine();

                                Console.Clear();

                                switch (pick)
                                {
                                    case "1":
                                        {
                                            foreach (Product product in Products)
                                            {
                                                try
                                                {
                                                    if (product is Wheat wheat)
                                                    {
                                                        wheat.Feed();
                                                    }
                                                    else if (product is Tomato tomato)
                                                    {
                                                        tomato.Feed();
                                                    }
                                                    else if (product is Sunflower sunflower)
                                                    {
                                                        sunflower.Feed();
                                                    }
                                                }
                                                catch (InvalidCastException ex)
                                                {
                                                    Console.WriteLine($"Error: {ex.Message}");
                                                }
                                            }

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nPress Enter To Back");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.ReadLine();
                                            Console.Clear();
                                            goto Back;
                                        }
                                    case "2":
                                        {
                                            foreach (Product product in Products)
                                            {
                                                try
                                                {
                                                    if (product is Wheat wheat)
                                                    {
                                                        wheat.ProvWater();
                                                    }
                                                    else if (product is Tomato tomato)
                                                    {
                                                        tomato.ProvWater();
                                                    }
                                                    else if (product is Sunflower sunflower)
                                                    {
                                                        sunflower.ProvWater();
                                                    }
                                                }
                                                catch (InvalidCastException ex)
                                                {
                                                    Console.WriteLine($"Error: {ex.Message}");
                                                }
                                            }
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nPress Enter To Back");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.ReadLine();
                                            Console.Clear();
                                            goto Back;
                                        }
                                    case "3":
                                        {
                                            foreach (Product product in Products)
                                            {
                                                try
                                                {
                                                    if (product is Wheat wheat)
                                                    {
                                                        if (wheat.IsWater() && wheat.IsFertilized())
                                                        {
                                                            player.AddReward(wheat.Harvest());
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Not enough Water or Fertilized");
                                                            Thread.Sleep(500);
                                                            goto Back;
                                                        }
                                                    }
                                                    else if (product is Tomato tomato)
                                                    {
                                                        if (tomato.IsWater() && tomato.IsFertilized())
                                                        {
                                                            player.AddReward(tomato.Harvest());
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Not enough Water or Fertilized");
                                                            Thread.Sleep(500);
                                                            goto Back;
                                                        }
                                                    }
                                                    else if (product is Sunflower sunflower)
                                                    {
                                                        if (sunflower.IsWater() && sunflower.IsFertilized())
                                                        {
                                                            player.AddReward(sunflower.Harvest());
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Not enough Water or Fertilized");
                                                            Thread.Sleep(500);
                                                            goto Back;
                                                        }
                                                    }
                                                }
                                                catch (InvalidCastException ex)
                                                {
                                                    Console.WriteLine($"Error: {ex.Message}");
                                                }
                                            }
                                            Products.Clear();
                                            //selectedProductsChoice.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nPress Enter To Back");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.ReadLine();
                                            Console.Clear();
                                            goto MainMenu;
                                        }
                                    case "4":
                                        {
                                            goto MainSeed;
                                        }
                                }
                            }
                            break;
                        }
                    case "2":
                        {
                            SerializeData(Users, filePath);
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            // Xử lý trường hợp không tìm thấy người dùng hoặc sản phẩm.
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Thread.Sleep(500);
                goto Login;
            }
            // Xử lý trường hợp nhập vào là null.
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Thread.Sleep(500);
                goto Login;
            }
        }
    }
}