using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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
                Thread.Sleep(800);


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
                Console.Write("Enter your choice: ");
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Choose Seed:\n");
                            Console.WriteLine("1. Wheat\n2. Tomato\n3. Sunflower\n4. Back\n");
                            Console.Write("Enter Your Choose: ");
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

                                Console.Clear();

                                selectedProduct.Seed();

                                Console.WriteLine();

                                Products.Add(selectedProduct);

                            Back:

                                Console.WriteLine("Choose method:\n");

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("1. Feed\n2. ProvWater\n3. Harvest:\n");
                                Console.Write("Enter your choose: ");
                                string pick = Console.ReadLine();

                                Console.Clear();

                                switch (pick)
                                {
                                    case "1":
                                        {
                                            foreach (Product product in Products)
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
                                            Console.WriteLine("\nPress Enter To Back");
                                            Console.ReadLine();
                                            Console.Clear();
                                            goto Back;
                                        }
                                    case "2":
                                        {
                                            foreach (Product product in Products)
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
                                            Console.WriteLine("\nPress Enter To Back");
                                            Console.ReadLine();
                                            Console.Clear();
                                            goto Back;
                                        }
                                    case "3":
                                        {
                                            foreach (Product product in Products)
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
                                            Products.RemoveAt(0);
                                            Console.WriteLine("\nPress Enter To Back");
                                            Console.ReadLine();
                                            Console.Clear();
                                            goto MainMenu;
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
        }
    }
}