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
            ILogger logger = new Logger();
            
            logger.InfoLogger(book.Genre.ToString() + book.Count);
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

        ILogger logger = new Logger();
            
        logger.InfoLogger(mostPopularGenre.Genre + " " + mostPopularGenre.Count);
        return null;
    }
}


internal class FindTopOldestBooks(List<Book> books) : ISort
{
    public List<Book> _books = books;

    public IEnumerable<Book> Sort()
    {
        var sortedBookByYear = _books.OrderByDescending(book => book.Year).Take(3);
        return sortedBookByYear;
    }
}

internal class FindBooksByAuthor(List<Book> books) : ISort
{
    public List<Book> _books = books;

    public IEnumerable<Book> Sort()
    {
        _books.GroupBy(book => book.Author).Select(group => new {Author = group.Key, Count = group.Count()});
        
        return null;
    }
}

internal class FindMostProductiveAuthor(List<Book> books) : ISort
{
    public List<Book> _books = books;

    public IEnumerable<Book> Sort()
    {
        ILogger logger = new Logger();
        
        var mostProductiveAuthor = _books.GroupBy(book => book.Author)
            .Select(group => new {Author = group.Key, Count = group.Count()})
            .OrderByDescending(group => group.Count).First();
        logger.InfoLogger(mostProductiveAuthor.Author + " " + mostProductiveAuthor.Count);
        return null;
    }
}

internal class AveragePublicationYear(List<Book> books) : ISort
{
    public List<Book> _books = books;
    

    public IEnumerable<Book> Sort()
    {
        ILogger logger = new Logger();
        var avgYear = _books.Average(book => book.Year);
        
        logger.InfoLogger(avgYear.ToString());
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