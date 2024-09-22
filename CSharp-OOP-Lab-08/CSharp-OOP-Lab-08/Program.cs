using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<string> selectedProductschoice = new List<string>();
            List<Product> Products = new List<Product>();
            List<Player> Users = new List<Player>()
            {
                new Player("A", 2000),
                new Player("B", 3000),
                new Player("C", 4000),
            };

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
                    Thread.Sleep(800);
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
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.Write("Enter Your Choose: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string seedChoice = Console.ReadLine();

                            Product selectedProduct = null;

                            switch (seedChoice)
                            {
                                case "1": selectedProduct = new Wheat(); break;
                                case "2": selectedProduct = new Tomato(); break;
                                case "3": selectedProduct = new Sunflower(); break;
                                case "4": goto MainMenu;
                            }

                            if (selectedProduct != null)
                            {                        
                                selectedProductschoice.Add(selectedProduct.Seed());

                                Products.Add(selectedProduct);

                            Back:
                                Console.Clear();

                                foreach (string choice in selectedProductschoice)
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
                                            Console.WriteLine("\nPress Enter To Back");
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
                                            Console.WriteLine("\nPress Enter To Back");
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
                                                        player.AddReward(wheat.Harvest());
                                                    }
                                                    else if (product is Tomato tomato)
                                                    {
                                                        player.AddReward(tomato.Harvest());
                                                    }
                                                    else if (product is Sunflower sunflower)
                                                    {
                                                        player.AddReward(sunflower.Harvest());
                                                    }
                                                }
                                                catch (InvalidCastException ex)
                                                {
                                                    Console.WriteLine($"Error: {ex.Message}");
                                                }
                                            }
                                            Products.Clear();
                                            Console.WriteLine("\nPress Enter To Back");
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
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Xử lý trường hợp không tìm thấy người dùng hoặc sản phẩm.
                Thread.Sleep(500);
                goto Login;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Xử lý trường hợp nhập vào là null.
                Thread.Sleep(500);
                goto Login;
            }
        }
    }
}