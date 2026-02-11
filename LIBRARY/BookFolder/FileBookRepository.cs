using System.Data;
using LIBRARY.BookFolder;
using LIBRARY.Enums;
using Newtonsoft.Json;

namespace LIBRARY;

internal class FileBookRepository(string path) : IBookRepository
{
    private string _path = path;
    //TODO: to add stack here? and how then i will access it?
    public List<Book> Read()
    {
        var jsonRead = "";
        try
        {
            using var r = new StreamReader(_path);
            jsonRead = r.ReadToEnd();
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            throw;
        }
        
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonRead);
        //JsonValidation.JsonValidate(books);//JsonException;
        return books;
    }

    public void Create(Book book)
    {
        var books = Read();
        
        try
        {
            books.Add(book);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentNullException(nameof(books));

        }
        WriteFile(books);
    }

    public void Update(Guid bookId,object paramToChange, UpdateParameter updateParameter = UpdateParameter.Name)
    {//get => fix => 
        var books = Read();
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);
        switch(updateParameter)//TODO: to add validation
        {
            case UpdateParameter.Name: findedBookToUpdate.Name = (string)paramToChange; break;//TODO: to add type validation to paramToChange
            case UpdateParameter.Author: findedBookToUpdate.Author = (string)paramToChange; break;
            case UpdateParameter.Year: findedBookToUpdate.Year = (int)paramToChange; break;
            case UpdateParameter.BorrowingBook:         //TODO: to create interface here
                if (findedBookToUpdate.BookIsCheckout)
                {
                    throw new ConstraintException("the book is already checkout");
                }
                findedBookToUpdate.BorrowingCount += 1;
                findedBookToUpdate.BookIsCheckout = true;
                findedBookToUpdate.BorrowDate = (DateTime)paramToChange; Console.WriteLine("returnDate:" + paramToChange.GetType()); 
                break;
            case UpdateParameter.ReturningBook:
                if (findedBookToUpdate.BookIsCheckout == false)
                {
                    throw new ConstraintException("the book is not checkout");
                }
                findedBookToUpdate.ReturnDate = (DateTime)paramToChange;
                findedBookToUpdate.BookIsCheckout = false;
                break;
            default: throw new ArgumentException("you typed in the wrong argument");
        }
        WriteFile(books);
    }

    public void Delete(Guid bookId)
    {
        var books = Read();
        if (books == null)
        {
            throw new FileNotFoundException();
        }
        
        var findedBookToDelete = books.Find(bookDatabase => bookDatabase.BookId == bookId);
        if (findedBookToDelete == null)
        { 
            throw new ArgumentNullException(nameof(bookId));
        }
        books.Remove(findedBookToDelete);
        WriteFile(books);
    }
    
    public void WriteFile(List<Book> books)
    {
        var jsonWrite = JsonConvert.SerializeObject(books, Formatting.Indented);
        File.WriteAllText(_path, jsonWrite);
    }
}