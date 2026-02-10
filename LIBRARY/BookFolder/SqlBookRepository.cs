using LIBRARY.BookFolder;
using LIBRARY.db;
using LIBRARY.Enums;

namespace LIBRARY;
public class SqlBookRepository : IBookRepository
{
    public List<Book>? Read()
    {
        var context = new MyDbContext();
        //List<Book> books = context.Book.;
        return null;
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
        Console.WriteLine("bookId:" + bookId + ":" + bookId.GetType() + ":" + bookId  );
        var book = new Book { BookId = bookId };
        context.Book.Remove(book);
        context.SaveChanges();
    }

    public void Update(Guid bookId, object paramToChange, UpdateParameter updateParameter = UpdateParameter.Name)
    {
        var context = new MyDbContext();
        var book = new Book { BookId = bookId };
        //var book = context.Book.Find(bookId);
        ILogger loggerMessages = new ConsoleLogger();
        var loggerForConsole = new Logger(loggerMessages);
        loggerForConsole.Logging(book?.BookId + " " + book?.Name + " " + book?.Author);
        //var book = context.Book.Find(1);
        switch (updateParameter) //TODO: to add validation
        {
            case UpdateParameter.Name: book.Name = (string)paramToChange;
                break;
            case UpdateParameter.Year: book.Year = (int)paramToChange;
                break;
            case UpdateParameter.Author: ;
                break;
            case UpdateParameter.BorrowingBook: ;
                break;
            case UpdateParameter.ReturningBook: ;
                break;
        }
    }
}