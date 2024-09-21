using System;
using System.Collections.Generic;
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

            List<Product> products = new List<Product>();
            products.Add(new Wheat());
            products.Add(new Tomato());
            products.Add(new Sunflower());

            List<Player> Users = new List<Player>()
            {
                new Player("A",2000),
                new Player("B",3000),
                new Player("C",4000),
                new Player("D",5000)
            };

            Login:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Menu Login\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Username: ");
            string username = Console.ReadLine();

            bool checkUser = false;
            foreach (Player p in Users)
            {
                if (p.CheckUser(username))
                {
                    checkUser = true;
                    break;
                }
            }

            if (checkUser)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome {username} Back To Your Farm !");

                Thread.Sleep(1000);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Giao Dịch:\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Seed\n2. Fertilizer\n3. Water\n");
                Console.Write("Enter Your Choose: ");
                string choose = Console.ReadLine();

                // Xử lí menu
                if (choose == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Choose Seed: ");
                    Console.WriteLine("1. Wheat\n2. Tomato\n3. Sunflower\n");
                    Console.Write("Enter Your Choose: ");
                    string seed = Console.ReadLine();
                    Console.WriteLine("Seed Successful");
                    Console.ForegroundColor= ConsoleColor.Red;

                    Product selectedProduct = null;
                    switch (seed)
                    {
                        case "1": selectedProduct = new Wheat(); break;
                        case "2": selectedProduct = new Tomato(); break;
                        case "3": selectedProduct = new Sunflower(); break;
                        default:
                            Console.WriteLine("Invalid seed selection.");
                            break;
                    }





                    Console.WriteLine("Press Enter To Menu");
                    Console.ReadLine();
                    goto Login;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Username wrong !\nEnter Your Username Again !");
                Thread.Sleep(1000);
                Console.Clear();
                goto Login;
            }
        }
    }
}
