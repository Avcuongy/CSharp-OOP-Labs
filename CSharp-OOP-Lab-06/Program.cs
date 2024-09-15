using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Lab_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Library lib = new Library();

            // Thêm sách
            lib.addBook(new Book("B01", "Lap trinh HDT", "Nguyen Van At", new DateTime(2023, 12, 20), "NXB DHQG HN", 240, 210000, 23));
            lib.addBook(new Book("B02", "Ly thuyet do thi", "Nguyen Van Mau", new DateTime(2022, 10, 12), "NXB DHBK HN", 250, 230000, 25));
            lib.addBook(new Book("B03", "Machine Learning", "Bukov", new DateTime(2022, 9, 30), "NXB DHBK HN", 144, 310000, 16));

            // Thêm User
            lib.addUser(new User("Billy Girmour", "M1"));
            lib.addUser(new User("Ronaldo", "M2"));
            lib.addUser(new User("Neymar", "M3"));

            // Danh sách sách
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Danh sách sách:");
            Console.ForegroundColor = ConsoleColor.White;
            PrintBooks(lib.Books);
            Console.WriteLine();

            //Danh sách user trong thư viện
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Danh sách Users:");
            Console.ForegroundColor = ConsoleColor.White;
            PrintUsers(lib.Users);
            Console.WriteLine();

            Console.Write("Nhập ID User: ");
            string id = Console.ReadLine();
            Console.WriteLine();

            if (lib.CheckIdUser(id))
            {
                Console.WriteLine("1. Mượn sách");
                Console.WriteLine("2. Trả sách");
                Console.WriteLine("3. In danh sách");
                string choose = "";
                do
                {
                    Console.WriteLine();
                    Console.Write("Phương thức bạn chọn: ");
                    choose = Console.ReadLine();
                    if (choose == "1")
                    {
                        Console.WriteLine();
                        Console.Write("Mã sách mượn: ");
                        string idBook = Console.ReadLine();
                        Console.Write("Số lượng mượn :");
                        int quantity = int.Parse(Console.ReadLine());
                        lib.BorrowBookById(id, idBook, (byte)quantity);
                        Console.WriteLine();
                    }
                    else if (choose == "2")
                    {
                        Console.WriteLine();
                        Console.Write("Mã sách trả: ");
                        string idBook = Console.ReadLine();
                        Console.Write("Số lượng trả :");
                        int quantity = int.Parse(Console.ReadLine());
                        lib.ReturnBookById(id, idBook, (byte)quantity);
                        Console.WriteLine();
                    }
                    else if (choose == "3")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Danh sách hiện tại: ");
                        PrintBooks(lib.Books);
                        Console.WriteLine();
                    }
                }
                while (choose != "1" || choose != "2");
            }
            else
                Console.WriteLine("Sai ID User. Try Again ");

            Console.ReadKey();
        }
        static void PrintBooks(List<Book> bks)
        {
            foreach (Book book in bks)
                Console.WriteLine(book);
        }
        static void PrintUsers(List<User> us)
        {
            foreach (User user in us)
            {
                Console.WriteLine(user);
            }
        }
    }
}
