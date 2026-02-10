using System.Collections;
using System.Data;
using LIBRARY.Enums;

namespace LIBRARY.BookFolder;

public class BookService
{
    private readonly IBookRepository _bookRepository;

    internal BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    internal void AddBookToLibrary(Book book)
    {
        _bookRepository.Create(book);
    }

    internal void DeleteBook(Guid bookId)
    {
        if (bookId == null)
        {
            throw new ArgumentNullException(nameof(bookId));
        }

        _bookRepository.Delete(bookId);
    }

    internal Guid? FindBookId(string? name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var books = _bookRepository.Read();
        if (books == null)
        {
            throw new FileNotFoundException();
            
        }
        var id = SearchByNameToId(name, books);
        return id;
    }

    internal Guid? SearchByNameToId(string? name, List<Book>? books)
    {
        if (name == null || books == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        var findedBook = books.Find(book => book.Name == name);
        if (findedBook == null)
        {
            throw new KeyNotFoundException();
        }
        return findedBook.BookId;
    }

    internal Book? SearchById(Guid bookId, List<Book> books)
    {
        var findedBook = books?.Find(book => book.BookId == bookId);
        return findedBook;
    }

    internal Book? GetBookById(Guid bookId)
    {
        var books = _bookRepository.Read();
        
        var findedBook = SearchById(bookId, books);
        return findedBook;
    }

    internal IEnumerable GetBookForPublic(SearchType searchType = SearchType.Name, string name = "", string author = "",
        int year = 0, Genre genre = Genre.Fiction)
    {
        var books = _bookRepository.Read();
        ISearch searchByAuthor = new ByAuthor(books);
        ISearch searchByName = new ByName(books);
        ISearch searchByYear = new ByYear(books);
        ISearch searchByGenre = new ByGenre(books);
        
        switch(searchType)
        {
            case SearchType.Author: 
                var startingSearchByAuthor = new SearchingBookForPublic(searchByAuthor); 
                return startingSearchByAuthor.Search(author);
            case SearchType.Name:
                var startingSearchByName = new SearchingBookForPublic(searchByName); 
                return startingSearchByName.Search(name);
            case SearchType.Year: 
                var startingSearchByYear = new SearchingBookForPublic(searchByYear); 
                return startingSearchByYear.Search(year); 
            case SearchType.Genre:
                var startingSearchByGenre = new SearchingBookForPublic(searchByGenre);
                return startingSearchByGenre.Search(genre);
        }
        return Enumerable.Empty<Book>();
    }
    
    internal void PrintoutBooks(IEnumerable<Book> books)//IEnumerable<Book> books
    {
        var ConsoleLoggerClass = new ConsoleLogger();
        foreach (var book in books)
        {
            Console.WriteLine("{0} - {1}", book.Name, book.BorrowingCount);
        }
    }
}