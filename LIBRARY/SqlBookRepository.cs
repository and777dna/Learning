namespace LIBRARY;

public class SqlBookRepository : IBookRepository
{
    public List<Book>? ReadFile()
    {
        return null;
    }
    public void AddToFile(Book book){}
    public void WriteFile(List<Book>? books){}
    public void DeleteFromFile(Guid? bookId){}
}