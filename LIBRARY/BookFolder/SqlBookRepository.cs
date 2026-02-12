using LIBRARY.BookFolder;
using LIBRARY.db;
using LIBRARY.Enums;
using LIBRARY.Logging;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY;
public class SqlBookRepository(Logger logger) : IBookRepository
{
    Logger _logger = logger;
    public List<Book> Read()
    {
        _logger.Logging("fds");//TODO: to make 7 kinds of logging
        var context = new MyDbContext();
        List<Book> books = context.Book.ToList();
        return books;
    }

    
    public void Create(Book book)
    {
        var context = new MyDbContext();//TODO: to make this to constructor
        if (book.BookId == Guid.Empty)
            book.BookId = Guid.NewGuid(); 
        context.Book.Add(book);
        context.SaveChanges();
    }

    public void Delete(Guid bookId)
    {
        var context = new MyDbContext();
        var book = new Book { BookId = bookId };
        context.Book.Remove(book);
        context.SaveChanges();
    }

    public void UpdateName(Guid bookId,string updatedName)
    {
        var context = new MyDbContext();
        
        var bookToUpdate = context.Book.FirstOrDefault(book => book.BookId == bookId);
        
        _logger.Logging(bookToUpdate?.BookId + " " + bookToUpdate?.Name + " " + bookToUpdate?.Author);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.Name = updatedName;
        context.SaveChanges();
    }
    
    public void UpdateYear(Guid bookId,int updatedYear)
    {
        var context = new MyDbContext();
        
        var bookToUpdate = context.Book.FirstOrDefault(book => book.BookId == bookId);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.Year = updatedYear;
        context.SaveChanges();
    }
    
    public void UpdateAuthor(Guid bookId,string updatedAuthor)
    {
        var context = new MyDbContext();
        
        var bookToUpdate = context.Book.FirstOrDefault(book => book.BookId == bookId);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.Author = updatedAuthor;
        context.SaveChanges();
    }
    
    public void UpdateBorrowingBook(Guid bookId,DateTime updatedBorrowDate)
    {
        var context = new MyDbContext();
        
        var bookToUpdate = context.Book.FirstOrDefault(book => book.BookId == bookId);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.BorrowDate = updatedBorrowDate;
        context.SaveChanges();
    }
    
    public void UpdateReturningBook(Guid bookId,DateTime updatedReturnDate)
    {
        var context = new MyDbContext();
        
        var bookToUpdate = context.Book.FirstOrDefault(book => book.BookId == bookId);
        if (bookToUpdate == null)
        {
            
        }
        bookToUpdate.ReturnDate = updatedReturnDate;
        context.SaveChanges();
    }
    
}