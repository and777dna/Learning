using LIBRARY.Logging;

namespace LIBRARY;

internal interface ISort
{
    internal IEnumerable<Book> Sort();
}

internal class SortByPopularity(List<Book> books) : ISort
{
    private List<Book> _books = books;
    public IEnumerable<Book> Sort()
    {
        return _books.OrderByDescending(book => book.BorrowingCount);
    }
}

internal class SortByGenreStatistics(List<Book> books) : ISort
{
    private List<Book> _books = books;
    public IEnumerable<Book> Sort()
    {
        foreach (var book in _books
                     .GroupBy(collumn => collumn.BookGenre)
                     .Select(group => new
                     {
                         Genre = group.Key,
                         Count = group.Count()
                     }).OrderBy(x => x.Genre))
        {   
            ILogger loggerMessages = new InfoLogger();
            var infoLogger = new Logger(loggerMessages);
            infoLogger.Logging(book.Genre.ToString() + book.Count);
        }

        return null;
    }
}

internal class FindTheMostPopularByGenre(List<Book> books) : ISort
{
    private List<Book> _books = books;
    public IEnumerable<Book> Sort()
    {
        var mostPopularGenre = _books
            .GroupBy(collumn => collumn.BookGenre)
            .Select(group => new
            {
                Genre = group.Key,
                Count = group.Count()
            }).OrderByDescending(x => x.Genre).First();

        ILogger loggerMessages = new InfoLogger();
        var infoLogger = new Logger(loggerMessages);
        infoLogger.Logging(mostPopularGenre.Genre.ToString() + " " + mostPopularGenre.Count);
        return null;
    }
}

internal class SortingBook
{
    private readonly ISort _sort;
    internal SortingBook(ISort sort)
    {
        _sort = sort;
    }
    
    public IEnumerable<Book> Sort()
    {
        return _sort.Sort();

    }
    
}