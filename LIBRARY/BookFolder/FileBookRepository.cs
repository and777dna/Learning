using System.Data;
using LIBRARY.BookFolder;
using LIBRARY.Enums;
using Newtonsoft.Json;

namespace LIBRARY;

internal class FileBookRepository(string path) : IBookRepository
{
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
            Console.WriteLine(e.Message);
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
            Console.WriteLine(e);
            throw new ArgumentNullException(nameof(books));

        }
        WriteFile(books);
    }
    
    
    public void UpdateField<TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter, UpdateDelegate<TUpdateParameter> up)
    {
        up(bookId, updateParameter);
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

    public void Delete(Guid bookId)
    {
        var books = Read();
        if (books == null)
        {
            throw new FileNotFoundException();
        }
        
        var findedBookToDelete = books.Find(bookDatabase => bookDatabase.BookId == bookId);
        if (findedBookToDelete == null)
        { 
            throw new ArgumentNullException(nameof(bookId));
        }
        books.Remove(findedBookToDelete);
        WriteFile(books);
    }
    
    public void WriteFile(List<Book> books)
    {
        var jsonWrite = JsonConvert.SerializeObject(books, Formatting.Indented);
        File.WriteAllText(_path, jsonWrite);
    }
}