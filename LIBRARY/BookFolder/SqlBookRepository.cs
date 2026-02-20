using LIBRARY.BookFolder;
using LIBRARY.db;
using LIBRARY.Logging;

namespace LIBRARY;
public class SqlBookRepository : IBookRepository
{
    private ILogger _logger;
    private MyDbContext _context;

    public SqlBookRepository(ILogger logger)
    {
        _logger = logger;
        _context = new MyDbContext();
    }
    public List<Book> Read()
    {
        List<Book> books = _context.Book.ToList();
        return books;
    }

    
    public void Create(Book book)
    {
        if (book.BookId == Guid.Empty)
            book.BookId = Guid.NewGuid(); 
        _context.Book.Add(book);
        _context.SaveChanges();
    }

    public Result.Result Delete(Guid bookId)
    {
        var findedBook = _context.Book.FirstOrDefault(book => book.BookId == bookId);
        _context.Book.Remove(findedBook);
        _context.SaveChanges();
        return Result.Result.Success();
    }
    public Result.Result UpdateField<TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter, UpdateDelegate<TUpdateParameter> up)//UpdateName(Guid bookId, string updatedName)
    {
        return Result.Result.Success();
    }

    public void UpdateName(Guid bookId,string updatedName)
    {
        
        var bookToUpdate = _context.Book.FirstOrDefault(book => book.BookId == bookId);
        
        _logger.DebugLogger(bookToUpdate?.BookId + " " + bookToUpdate?.Name + " " + bookToUpdate?.Author);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.Name = updatedName;
        _context.SaveChanges();
    }
    
    public void UpdateYear(Guid bookId,int updatedYear)
    {
        var bookToUpdate = _context.Book.FirstOrDefault(book => book.BookId == bookId);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.Year = updatedYear;
        _context.SaveChanges();
    }
    
    public void UpdateAuthor(Guid bookId,string updatedAuthor)
    {
        var bookToUpdate = _context.Book.FirstOrDefault(book => book.BookId == bookId);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.Author = updatedAuthor;
        _context.SaveChanges();
    }
    
    public void UpdateBorrowingBook(Guid bookId,DateTime updatedBorrowDate)
    {
        var bookToUpdate = _context.Book.FirstOrDefault(book => book.BookId == bookId);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.BorrowDate = updatedBorrowDate;
        _context.SaveChanges();
    }
    
    public void UpdateReturningBook(Guid bookId,DateTime updatedReturnDate)
    {
        var bookToUpdate = _context.Book.FirstOrDefault(book => book.BookId == bookId);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.ReturnDate = updatedReturnDate;
        _context.SaveChanges();
    }
    
}