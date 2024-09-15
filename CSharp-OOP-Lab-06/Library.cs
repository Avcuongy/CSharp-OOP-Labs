using CSharp_OOP_Lab_06;
using System;
using System.Collections.Generic;

public class Library
{
    private List<Book> books = new List<Book>();
    private List<User> users = new List<User>();
    public List<Book> Books { get => books; set => books = value; }
    public List<User> Users { get => users; set => users = value; }

    public Library()
    {
        this.Books = books;
        this.Users = users;
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
    public void BorrowBookById(string idUser, string id, byte amount)
    {
        Book book = books.Find(b => b.ToString().Contains(id));
        if (book != null)
        {
            if (book.IsAvailable(amount))
            {
                book.BorrowBook(amount);
                Console.WriteLine($"{idUser} đã mượn thành công {amount} sách của mã sách \"{id}\"");
            }
            else
            {
                Console.WriteLine("Out Of Limit số sách có thể mượn");
            }
        }
    }
    public void ReturnBookById(string idUser, string id, byte amount)
    {
        Book book = books.Find(b => b.ToString().Contains(id));
        if (book != null)
        {
            book.ReturnBook(amount);
            Console.WriteLine($"{idUser} trả thành công {amount} sách của mã sách \"{id}\"");
        }
        else
        {
            Console.WriteLine($"{idUser} không mượn bất kì sách nào");
        }
    }
    public void addUser(User user)
    {
        users.Add(user);
    }
    public string ChooseUser(string idUser)
    {
        string builder = "";
        foreach (User user in users)
        {
            if (user.IdUser == idUser)
            {
                builder = $"Chào mừng {user} tới với library";
                break;
            }
            else
            {
                builder = "No User Found !";
            }
        }
        return builder;
    }
    public bool CheckIdUser(string idUser)
    {
        bool check = false;
        foreach (User user in users)
        {
            if (user.IdUser == idUser)
                check = true;
        }
        return check;
    }
}