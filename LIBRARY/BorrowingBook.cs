namespace LIBRARY;

public class BorrowingBook
{
    internal void BorrowBook(Guid bookId, Guid ticketNumber)
    {
        if (bookId == null) { throw new ArgumentNullException(nameof(bookId)); }
        var BookServiceClass = new BookService(BookRepository.ReadJsonFile());//TODO: Reader.CurrenCheckoutBook = Book.BookId

        var readers = ReaderRepository.ReadJsonFile();
        var readerDatabase = new ReaderService(readers);
        
        BookServiceClass.UpdateBook(bookId, UpdateParameter.BorrowingBook, borrowDate: DateTime.Now);
        readerDatabase.UpdateReader(ticketNumber, bookId, true);
    }
   
    public static void DisplayByBorrowingPopularity()//TODO: to make DI here
    {
        var books = BookRepository.ReadJsonFile();
        if(books == null){throw new FileNotFoundException();}

        ISort sortByPopularity = new SortByPopularity(books);
       
        var sortClass = new SortingBook(sortByPopularity);
        var sortedByPopularity = sortClass.Sort();
        
        var BookServiceClass = new BookService(BookRepository.ReadJsonFile());
        BookServiceClass.PrintoutBooks(sortedByPopularity);
    }
    
    internal void ReturnBook(Guid bookId, Guid ticketNumber)
    {
        var readers = ReaderRepository.ReadJsonFile();
        var readerDatabase = new ReaderService(readers);
        var BookServiceClass = new BookService(BookRepository.ReadJsonFile());
        
        Console.WriteLine("Guid ticketNumber, Guid bookId:" + ticketNumber + " " + bookId);
        BookServiceClass.UpdateBook(bookId, UpdateParameter.ReturningBook, borrowDate: DateTime.Now.AddDays(7));
        readerDatabase.UpdateReader(ticketNumber,Guid.Empty, false);
    }
}