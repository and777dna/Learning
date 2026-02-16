using LIBRARY.BookFolder;
using LIBRARY.Logging;

namespace LIBRARY;

public class BorrowingBook
{
    private readonly IBookRepository _bookRepository;
    private ILogger _logger;
    internal BorrowingBook(IBookRepository bookRepository, ILogger logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }
    internal void BorrowBook(Guid bookId, Guid ticketNumber)
    {
        var readers = ReaderRepository.ReadJsonFile();
        var readerDatabase = new ReaderService(readers);

        string _path = Path.Combine(AppContext.BaseDirectory, "books.json");
        var BookRepositoryClass = new FileBookRepository(_path);
        
        _bookRepository.UpdateField(bookId, DateTime.Now, BookRepositoryClass.UpdateBorrowingBook);
        
        
        readerDatabase.UpdateReader(ticketNumber, bookId, true);
    }
   
    public static void DisplayByBorrowingPopularity()//TODO: to make DI here
    {
        string _path = Path.Combine(AppContext.BaseDirectory, "books.json");
        //var books = BookRepository.ReadJsonFile();

        IBookRepository BookOperationsClass = new FileBookRepository(_path);
        var books = BookOperationsClass.Read();
        if(books == null){throw new FileNotFoundException();}

        ISort sortByPopularity = new SortByPopularity(books);
       
        var sortClass = new SortingBook(sortByPopularity);
        var sortedByPopularity = sortClass.Sort();
        
        ILogger loggerInfoMessages = new InfoLogger();
        
        
        var BookServiceClass = new BookService(BookOperationsClass, loggerInfoMessages);
        BookServiceClass.PrintoutBooks(sortedByPopularity);
    }
    
    internal void ReturnBook(Guid bookId, Guid ticketNumber)
    {
        var readers = ReaderRepository.ReadJsonFile();
        var readerDatabase = new ReaderService(readers);
        
        string _path = Path.Combine(AppContext.BaseDirectory, "books.json");
        var BookRepositoryClass = new FileBookRepository(_path);
        
        _bookRepository.UpdateField(bookId, DateTime.Now.AddDays(7), BookRepositoryClass.UpdateReturningBook);
        readerDatabase.UpdateReader(ticketNumber,Guid.Empty, false);
    }
}