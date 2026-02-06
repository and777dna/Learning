using LIBRARY.BookFolder;
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
        var bookToAdd = new Book("Fyodor Dostoevsky", "Crime and Punishment", 1866, new Guid(), Genre.History) { Name = "Crime and Punishment" };
        context.Book.Add(bookToAdd);
        context.SaveChanges();
    }
    public void Delete(Guid? bookId){}
    public void Update(Guid? bookId, object paramToChange, UpdateParameter updateParameter = UpdateParameter.Name){}
}