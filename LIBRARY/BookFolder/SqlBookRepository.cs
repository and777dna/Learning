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
       //var bookToAdd = new Book("Fyodor Dostoevsky", "Crime and Punishment", 1866, new Guid(), Genre.History) { Name = "Crime and Punishment" };
        //context.Book.Add(book);
        var bookToAdd = new Book("Fyodor Dostoevsky", "Crime and Punishment", 1866, Genre.History) { Name = "Crime and Punishment", Author = "Fyodor Dostoevsky", Year = 1866, BookGenre = Genre.History};
        if (book.BookId == Guid.Empty)
            book.BookId = Guid.NewGuid(); 
        Console.WriteLine("bookToAdd " + bookToAdd.Author);
        context.Book.Add(bookToAdd);
        context.SaveChanges();
    }
    public void Delete(Guid? bookId){}
    public void Update(Guid? bookId, object paramToChange, UpdateParameter updateParameter = UpdateParameter.Name){}
}