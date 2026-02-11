using LIBRARY.BookFolder;
using LIBRARY.db;
using LIBRARY.Enums;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY;
public class SqlBookRepository : IBookRepository
{
    public List<Book> Read()
    {
        var context = new MyDbContext();
        List<Book> books = context.Book.ToList();
        return books;
    }

    
    public void Create(Book book)
    {
        var context = new MyDbContext();//TODO: to make this to constructor
        if (book.BookId == Guid.Empty)
            book.BookId = Guid.NewGuid(); 
        context.Book.Add(book);
        context.SaveChanges();
    }

    public void Delete(Guid bookId)
    {
        var context = new MyDbContext();
        var book = new Book { BookId = bookId };
        context.Book.Remove(book);
        context.SaveChanges();
    }

    
    public void Update(Guid bookId, object paramToChange, UpdateParameter updateParameter = UpdateParameter.Name)
    {
        var context = new MyDbContext();
        var book = new Book { BookId = bookId };

        var bookToUpdate = context.Book.First(book => book.BookId == bookId);

        
        ILogger loggerMessages = new ConsoleLogger();
        var loggerForConsole = new Logger(loggerMessages);
        loggerForConsole.Logging(book?.BookId + " " + book?.Name + " " + book?.Author);

        switch (updateParameter) //TODO: to add validation
        {
            case UpdateParameter.Name: bookToUpdate.Name = (string)paramToChange;
                context.SaveChanges();
                break;
            case UpdateParameter.Year: book.Year = (int)paramToChange;
                context.SaveChanges();
                break;
            case UpdateParameter.Author: book.Author = (string)paramToChange;
                context.SaveChanges();
                break;
            case UpdateParameter.BorrowingBook: book.BorrowDate = (DateTime)paramToChange;
                context.SaveChanges();
                break;
            case UpdateParameter.ReturningBook: book.ReturnDate = (DateTime)paramToChange;
                context.SaveChanges();
                break;
        }
    }
}