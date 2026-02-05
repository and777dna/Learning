using LIBRARY.BookFolder;
using LIBRARY.Enums;

namespace LIBRARY;

public class BorrowingBook
{
    private readonly IBookRepository _bookRepository;

    internal BorrowingBook(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    internal void BorrowBook(Guid bookId, Guid ticketNumber)
    {
        if (bookId == null) { throw new ArgumentNullException(nameof(bookId)); }
        
        
        var readers = ReaderRepository.ReadJsonFile();
        var readerDatabase = new ReaderService(readers);
        
        _bookRepository.Update(bookId, DateTime.Now, UpdateParameter.BorrowingBook);
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
        
        var BookServiceClass = new BookService(BookOperationsClass);
        BookServiceClass.PrintoutBooks(sortedByPopularity);
    }
    
    internal void ReturnBook(Guid bookId, Guid ticketNumber)
    {
        var readers = ReaderRepository.ReadJsonFile();
        var readerDatabase = new ReaderService(readers);
        
        Console.WriteLine("Guid ticketNumber, Guid bookId:" + ticketNumber + " " + bookId);
        _bookRepository.Update(bookId, DateTime.Now.AddDays(7), UpdateParameter.ReturningBook);
        //BookServiceClass.UpdateBook(bookId, UpdateParameter.ReturningBook, borrowDate: DateTime.Now.AddDays(7));
        readerDatabase.UpdateReader(ticketNumber,Guid.Empty, false);
    }
}