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
            lib.addBook(new Book("B01", "Lap trinh HDT", "Nguyen Van At", new DateTime(2023, 12, 20), "NXB DHQG HN", 240, 210000, 23));
            lib.addBook(new Book("B02", "Ly thuyet do thi", "Nguyen Van Mau", new DateTime(2022, 10, 12), "NXB DHBK HN", 250, 230000, 25));

            // Danh sách sách
            Console.WriteLine("Danh sách sách:");
            PrintBooks(lib.Books);

            // Mượn sách
            Console.WriteLine("\nMượn sách:");
            lib.BorrowBook("B01", 5);

            // In sách sau khi mượn
            Console.WriteLine("\nDanh sách sách sau khi mượn:");
            PrintBooks(lib.Books);

            // Trả sách
            Console.WriteLine("\nTrả sách:");
            lib.ReturnBook("B01", 3);

            // In sách sau khi trả
            Console.WriteLine("\nDanh sách sách sau khi trả:");
            PrintBooks(lib.Books);

            Console.ReadKey();
        }
        static void PrintBooks(List<Book> bks)
        {
            foreach (Book book in bks)
                Console.WriteLine(book);
        }
    }
}
