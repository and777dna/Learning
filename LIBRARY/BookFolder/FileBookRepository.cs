using LIBRARY.BookFolder;
using LIBRARY.Enums;
using LIBRARY.Logging;
using Newtonsoft.Json;

namespace LIBRARY;


internal class FileBookRepository : IBookRepository
{
    private ILogger _logger;
    private string _path;
    //TODO: to add stack here? and how then i will access it?
    public List<Book> Books { private set; get; }//TODO: to understand why when i put public, than i cant read it
    

    internal FileBookRepository(string path, ILogger logger)
    {
        _logger = logger;
        _path = path;
        Books = Read();
    }
    
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
            _logger.ErrorLogger(e.Message);
            throw;
        }
        
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonRead);
        //JsonValidation.JsonValidate(books);//JsonException;
        return books;
    }

    public void Create(Book book)
    {
        var books = Books;
        
        try
        {
            books.Add(book);
        }
        catch (Exception e)
        {
            _logger.ErrorLogger(e.Message);
            throw new ArgumentNullException(nameof(books));

        }
        WriteFile(books);
    }
    
    /*
 Operation operation = SelectOperation(OperationType.Add);
   Console.WriteLine(operation(10, 4));    // 14

   Operation SelectOperation(OperationType opType)
   {
       switch (opType)
       {
           case OperationType.Add: return Add;
           case OperationType.Subtract: return Subtract;
           default: return Multiply;
       }
   }
    */
    /*public delegate Result.Result Updatefield<TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter);

    Updatefield<TUpdateParameter> SelectUpdate<TUpdateParameter>(UpdateType upType)
    {
        switch (upType)
        {
            case UpdateType.UpdateAuthor: return Updateauthor<TUpdateParameter>;
        }

        return Updateauthor;
    }

    Updatefield<string> operation = SelectUpdate<string>(UpdateType.UpdateAuthor);
    
    public Result.Result Updateauthor<TUpdateParameter>(Guid bookId, TUpdateParameter updatedAuthor)
    {
        var books = Books;
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.Author = updatedAuthor.ToString();
        WriteFile(books);
    }*/
    
    public delegate Result.Result Updatefield<TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter);
    public delegate Result.Result Updateffield<T, TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter);
    

    public Updatefield<TUpdateParameter> SelectOperation<TUpdateParameter>(UpdateType upType)
    {
        return Updatename;
    }
    
    public Result.Result Updatename<TUpdateParameter>(Guid bookId, TUpdateParameter updatedName)
    {
        var books = Books;
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.Name = updatedName.ToString();
        WriteFile(books);
        return Result.Result.Success();
    }
    
    
    
    
    
    public Result.Result UpdateField<TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter, UpdateDelegate<TUpdateParameter> up)
    {
        up(bookId, updateParameter);
        return Result.Result.Success();
    }
    
    public void UpdateName(Guid bookId, string updatedName)
    {
        var books = Books;
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.Name = updatedName;
        WriteFile(books);
    }

    public void UpdateYear(Guid bookId, int updatedYear)
    {
        var books = Books;
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.Year = updatedYear;
        WriteFile(books);
    }

    public void UpdateAuthor(Guid bookId, string updatedAuthor)
    {
        var books = Books;
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.Author = updatedAuthor;
        WriteFile(books);
    }

    public void UpdateBorrowingBook(Guid bookId, DateTime updatedBorrowDate)
    {
        var books = Books;
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.BorrowDate = updatedBorrowDate;
        WriteFile(books);
    }

    public void UpdateReturningBook(Guid bookId, DateTime updatedReturnDate)
    {
        var books = Books;
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.BookId == bookId);//TODO: to add validation
        findedBookToUpdate.ReturnDate = updatedReturnDate;
        WriteFile(books);
    }

    public Result.Result Delete(Guid bookId)
    {
        var books = Books;
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