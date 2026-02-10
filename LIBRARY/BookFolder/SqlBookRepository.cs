using LIBRARY.BookFolder;
using LIBRARY.db;
using LIBRARY.Enums;

namespace LIBRARY;
public class SqlBookRepository : IBookRepository
{
    public List<Book>? Read()
    {
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
    public void Update(Guid? bookId, object paramToChange, UpdateParameter updateParameter = UpdateParameter.Name){}
}