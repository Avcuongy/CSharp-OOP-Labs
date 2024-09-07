using CSharp_OOP_Lab_06;
using System;
using System.Collections.Generic;

public class Library
{
    private List<Book> books = new List<Book>();

    public Library()
    {
        this.Books = books;
    }

    public void addBook(Book book)
    {
        books.Add(book);
    }

    public List<Book> find(string keyword)
    {
        List<Book> result = new List<Book>();
        foreach (Book b in books)
            if (b.find(keyword))
                result.Add(b);
        return result;
    }
    public List<Book> Books { get => books; set => books = value; }

    public void BorrowBook(string id, byte amount)
    {
        Book book = books.Find(b => b.ToString().Contains(id));
        if (book != null)
        {
            if (book.IsAvailable(amount))
            {
                book.BorrowBook(amount);
                Console.WriteLine($"Mượn {amount} sách của mã sách {id}");
            }
            else
            {
                Console.WriteLine("Out Of Limit số sách có thể mượn");
            }
        }
    }
    public void ReturnBook(string id, byte amount)
    {
        Book book = books.Find(b => b.ToString().Contains(id));
        if (book != null)
        {
            book.ReturnBook(amount);
            Console.WriteLine($"Trả {amount} sách của mã sách {id}");
        }
        else
        {
            Console.WriteLine("Bạn không mượn bất kì sách nào");
        }
    }
}