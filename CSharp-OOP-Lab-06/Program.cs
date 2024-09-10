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

            // Chọn thẻ user của bạn
            Console.Write("Nhập ID User của bạn: ");
            string idUser = Console.ReadLine();
            Console.WriteLine(lib.ChooseUser(idUser));
            Console.WriteLine();

            if (lib.CheckIdUser(idUser))
            {
                // Tìm kiếm theo tên sách hoặc tác giả
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nKết quả tìm kiếm:");
                Console.ForegroundColor = ConsoleColor.White;
                PrintBooks(lib.find("Lap trinh HDT"));
                PrintBooks(lib.find("Bukov"));

                // Mượn sách
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nMượn sách:");
                Console.ForegroundColor = ConsoleColor.White;
                lib.BorrowBookById(idUser, "B01", 3);
                lib.BorrowBookById(idUser, "B03", 3);

                // In sách sau khi mượn
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDanh sách sách sau khi mượn:");
                Console.ForegroundColor = ConsoleColor.White;
                PrintBooks(lib.Books);

                // Trả sách
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTrả sách:");
                Console.ForegroundColor = ConsoleColor.White;
                lib.ReturnBookById(idUser, "B01", 1);
                lib.ReturnBookById(idUser, "B03", 3);

                // In sách sau khi trả
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDanh sách sách sau khi trả:");
                Console.ForegroundColor = ConsoleColor.White;
                PrintBooks(lib.Books);
            }
            else
            {
                Console.WriteLine("Bạn cần đăng kí thẻ thư viện");
            }
            Console.ReadKey();
        }
        static void PrintBooks(List<Book> bks)
        {
            foreach (Book book in bks)
                Console.WriteLine(book);
        }
        static void PrintUsers(List<User> us)
        {
            foreach(User user in us)
            {
                Console.WriteLine(user);
            }    
        }
    }
}
