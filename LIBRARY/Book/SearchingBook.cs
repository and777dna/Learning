using Library.customJSONutils;

namespace Library.Book;

public static class SearchingBook
{
    internal static Book NameSearch(string name)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        
        List<Book> books = Json.ReadJsonFile(filePath);

        Book findedBook = books.Find(book => book.Name == name);
        return findedBook;
    }

    internal static Book AuthorSeach(string author)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        
        List<Book> books = Json.ReadJsonFile(filePath);

        Book findedBook = books.Find(book => book.Author == author);
        return findedBook;
    }

    internal static Book YearSearch(int year)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        
        List<Book> books = Json.ReadJsonFile(filePath);

        Book findedBook = books.Find(book => book.Year == year);
        return findedBook;
    }
}