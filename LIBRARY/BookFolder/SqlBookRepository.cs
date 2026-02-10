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
        var context = new MyDbContext();
        if (book.BookId == Guid.Empty)
            book.BookId = Guid.NewGuid(); 
        context.Book.Add(book);
        context.SaveChanges();
    }
    
    public void Delete(Guid? bookId){}
    public void Update(Guid? bookId, object paramToChange, UpdateParameter updateParameter = UpdateParameter.Name){}
}