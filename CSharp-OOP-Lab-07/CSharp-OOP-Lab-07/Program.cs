using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_07
{
    internal class Program
    {
        // Phương thúc in ra sự kiện
        static void HandleTransaction(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ATM use = new ATM();

            use.AddAccount(new Account("A", "0340000001", 1000000m));
            use.AddAccount(new Account("B", "0002341502", 2000000m));
            use.AddAccount(new Account("C", "9923700003", 3000000m));

            use.HaveTransaction += HandleTransaction;

            LoginMenu:
            Console.Write("Nhập Username: ");
            string name = Console.ReadLine();

            if (use.CheckAccount(name))
            {
            Restart:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Menu Giao Dịch\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("1. Rút Tiền");
                Console.WriteLine("2. Chuyển Tiền");
                Console.WriteLine("3. In danh sách Account");
                Console.WriteLine("4. Quay Về Màn Hình Login");
                Console.WriteLine("5. Đóng Chương Trình\n");

                Console.Write("Nhập giao dịch muốn thực hiện: ");
                string choose = Console.ReadLine();

                Console.Clear();

                switch (choose)
                {
                    case "1":
                        {
                            Console.Write("Số tiền muốn rút: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                            {
                                Console.WriteLine();
                                use.Draw(name, amount);
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPress Enter To Back Menu");
                            Console.ReadLine();
                            goto Restart;
                        }
                    case "2":
                        {
                            Console.Write("Username người nhận: ");
                            string receiver = Console.ReadLine();
                            Console.Write("Số tiền gửi: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                            {
                                Console.WriteLine();
                                use.Transfer(name, receiver, amount);
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPress Enter To Back Menu");
                            Console.ReadLine();
                            goto Restart;
                        }
                    case "3":
                        {
                            use.PrintAccounts(use.Accounts);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPress Enter To Back Menu");
                            Console.ReadLine();
                            goto Restart;
                        }
                    case "4":
                        {                        
                            goto LoginMenu;
                        }
                    case "5":
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            Console.ReadKey();
        }
    }
}
