using System.Collections;
using System.Data;
using LIBRARY.Enums;
using LIBRARY.Logging;
using LIBRARY.Result;

namespace LIBRARY.BookFolder;

public class BookService
{
    private ILogger _logger;
    private readonly IBookRepository _bookRepository;

    internal BookService(IBookRepository bookRepository, ILogger logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }

    internal void AddBookToLibrary(Book book)
    {
        _bookRepository.Create(book);
    }

    internal void DeleteBook(Guid bookId)
    {
        _bookRepository.Delete(bookId);
    }

    internal Result<Guid> FindBookId(string name)
    {
        var books = _bookRepository.Read();
        if (books == null)
        {
            return Result<Guid>.Failure("no file was found");//TODO: to return failure? or log?
        }
        var result = SearchByNameToId(name, books);
        return Result<Guid>.Success(result.Value); //id._value;
    }

    internal Result<Guid> SearchByNameToId(string name, List<Book> books)
    {
        var findedBook = books.Find(book => book.Name == name);
        if (findedBook == null)
        {
            return Result<Guid>.Failure("no book was found");
        }
        return Result<Guid>.Success(findedBook.BookId);
    }

    internal Result<Book> SearchById(Guid bookId, List<Book> books)
    {
        var findedBook = books.Find(book => book.BookId == bookId);
        if (findedBook == null)
        {
            return Result<Book>.Failure("no book was found");
        }
        return Result<Book>.Success(findedBook);
    }

    internal Result<Book> GetBookById(Guid bookId)
    {
        var books = _bookRepository.Read();
        
        var findedBook = SearchById(bookId, books);
        if (!findedBook.IsSuccess) return Result<Book>.Failure("no book ID was found");
        return findedBook;
    }

    internal Result<IEnumerable> GetBookForPublic(SearchType searchType = SearchType.Name, string name = "", string author = "",
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
                return Result<IEnumerable>.Success(startingSearchByAuthor.Search(author));
            case SearchType.Name:
                var startingSearchByName = new SearchingBookForPublic(searchByName);
                return Result<IEnumerable>.Success(startingSearchByName.Search(name));
            case SearchType.Year: 
                var startingSearchByYear = new SearchingBookForPublic(searchByYear);
                return Result<IEnumerable>.Success(startingSearchByYear.Search(year));
            case SearchType.Genre:
                var startingSearchByGenre = new SearchingBookForPublic(searchByGenre);
                return Result<IEnumerable>.Success(startingSearchByGenre.Search(genre));
        }
        return Result<IEnumerable>.Failure("failure in getting object");
    }
    
    internal void PrintoutBooks(IEnumerable<Book> books)//IEnumerable<Book> books
    {
        foreach (var book in books)
        {
            _logger.Log(book.Name + book.BorrowingCount);
        }
    }
}