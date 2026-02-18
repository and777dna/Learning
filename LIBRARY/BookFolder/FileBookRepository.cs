using LIBRARY.BookFolder;
using LIBRARY.Logging;
using Newtonsoft.Json;

namespace LIBRARY;

internal class FileBookRepository(string path, ILogger logger) : IBookRepository
{
    private ILogger _logger = logger;//TODO: to make not .Log() here, but error(), infoLog()
    private string _path = path;
    //TODO: to add stack here? and how then i will access it?
    public List<Book> Read()
    {
        var jsonRead = "";
        try
        {
            using var r = new StreamReader(_path);
            jsonRead = r.ReadToEnd();
        }
        catch (Exception e)
        {
            _logger.Log(e.Message);
            throw;
        }
        
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonRead);
        //JsonValidation.JsonValidate(books);//JsonException;
        return books;
    }

    public void Create(Book book)
    {
        var books = Read();
        
        try
        {
            books.Add(book);
        }
        catch (Exception e)
        {
            _logger.Log(e.Message);
            throw new ArgumentNullException(nameof(books));

        }
        WriteFile(books);
    }
    
    
    public Result.Result UpdateField<TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter, UpdateDelegate<TUpdateParameter> up)
    {
        up(bookId, updateParameter);
        return Result.Result.Success();
    }
    
    public void UpdateName(Guid bookId, string updatedName)
    {
        var books = Read();
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.Name = updatedName;
        WriteFile(books);
    }

    public void UpdateYear(Guid bookId, int updatedYear)
    {
        var books = Read();
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.Year = updatedYear;
        WriteFile(books);
    }

    public void UpdateAuthor(Guid bookId, string updatedAuthor)
    {
        var books = Read();
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.Author = updatedAuthor;
        WriteFile(books);
    }

    public void UpdateBorrowingBook(Guid bookId, DateTime updatedBorrowDate)
    {
        var books = Read();
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.BorrowDate = updatedBorrowDate;
        WriteFile(books);
    }

    public void UpdateReturningBook(Guid bookId, DateTime updatedReturnDate)
    {
        var books = Read();
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.ReturnDate = updatedReturnDate;
        WriteFile(books);
    }

    public Result.Result Delete(Guid bookId)
    {
        var books = Read();
        if (books == null)
        {
            return Result.Result.Failure("books are not inside cache");
        }
        
        var findedBookToDelete = books.Find(bookDatabase => bookDatabase.BookId == bookId);
        if (findedBookToDelete == null)
        {
            return Result.Result.Failure("book is not founded");
        }
        books.Remove(findedBookToDelete);
        WriteFile(books);
        return Result.Result.Success();
    }
    
    
    public void WriteFile(List<Book> books)
    {
        var jsonWrite = JsonConvert.SerializeObject(books, Formatting.Indented);
        File.WriteAllText(_path, jsonWrite);
    }
}