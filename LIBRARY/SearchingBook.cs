using Library;
using LIBRARY;


public static class SearchingBook
{
    internal static Book? NameSearch(string name)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        
        var books = Json.ReadJsonFile(filePath);

        var findedBook = books?.Find(book => book.Name == name);
        Utils.SearchValidation(findedBook);
        return findedBook;
    }

    internal static Book? AuthorSeach(string author)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        
        var books = Json.ReadJsonFile(filePath);

        var findedBook = books?.Find(book => book.Author == author);
        Utils.SearchValidation(findedBook);
        return findedBook;
    }

    internal static Book? YearSearch(int year)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        
        var books = Json.ReadJsonFile(filePath);

        var findedBook = books?.Find(book => book.Year == year);

        Utils.SearchValidation(findedBook);
        
        return findedBook;
    }
}