using System.Collections;
using LIBRARY.Enums;

namespace LIBRARY;

internal interface ISearch
{
    internal IEnumerable Search(object searchWord);
}
internal class ByYear(List<Book> books) : ISearch
{
    private List<Book>? _books = books;
    public IEnumerable Search(object year)
    {
        return _books?.Where(b => b.Year == (int)year) ?? Enumerable.Empty<Book>();
    }
}

internal class ByGenre(List<Book> books) : ISearch
{
    private List<Book>? _books = books;
    public IEnumerable Search(object genre)
    {
        return _books?.Where(b => b.BookGenre == (Genre)genre) ?? Enumerable.Empty<Book>();
    }
}

internal class ByAuthor(List<Book> books) : ISearch
{
    private List<Book>? _books = books;
    public IEnumerable Search(object author)
    {
        return _books?.Where(b => b.Author == (string)author) ?? Enumerable.Empty<Book>();
    }
}

internal class ByName(List<Book> books) : ISearch
{
    private List<Book>? _books = books;
    public IEnumerable Search(object name)
    {
        return _books?.Where(b => b.Author == (string)name) ?? Enumerable.Empty<Book>();
    }
}

public class SearchingBookForPublic
{
    private readonly ISearch _search;
    internal SearchingBookForPublic(ISearch search)
    {
        _search = search;
    }
    
    public IEnumerable Search(object typeOfSearch)
    {
        return _search.Search(typeOfSearch);
    }
    
}