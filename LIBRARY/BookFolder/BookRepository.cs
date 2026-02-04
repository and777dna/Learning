using Newtonsoft.Json;
using Exception = System.Exception;
using FileNotFoundException = System.IO.FileNotFoundException;

namespace LIBRARY;

//TODO: to make DI here
public static class BookRepository
{
    private static string _path = Path.Combine(AppContext.BaseDirectory, "books.json");
    internal static List<Book>? ReadJsonFile()
    {
        var jsonRead = "";
        try
        {
            using var r = new StreamReader(_path);
            jsonRead = r.ReadToEnd();
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            throw;
        }
        
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonRead);
        //JsonValidation.JsonValidate(books);//JsonException;
        return books;
    }
    
    internal static void AddToJsonFile(Book book)
    {
        var books = ReadJsonFile();
        
        try
        {
            books.Add(book);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentNullException(nameof(books));

        }
        WriteJsonFile(books);
        
    }

    internal static void WriteJsonFile(List<Book>? books)
    {
        var jsonWrite = JsonConvert.SerializeObject(books, Formatting.Indented);
        File.WriteAllText(_path, jsonWrite);
    }
    
    internal static void DeleteFromJsonFile(Guid? bookId)
    {
        var books = ReadJsonFile();
        if (books == null)
        {
            throw new FileNotFoundException();
        }
        
        var findedBookToDelete = books?.Find(bookDatabase => bookDatabase.BookId == bookId);
        if (findedBookToDelete == null)
        { 
            throw new ArgumentNullException(nameof(bookId));
        }
        books?.Remove(findedBookToDelete);
        WriteJsonFile(books);
    }
}