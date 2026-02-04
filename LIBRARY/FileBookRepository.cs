using Newtonsoft.Json;

namespace LIBRARY;

internal interface IBookRepository
{
    public List<Book>? ReadFile();//Non-abstract and non-extern method must declare a body
    internal void AddToFile(Book book);//Non-public method 'ReadJsonFile' cannot implement method from interface IBookRepository
    internal void WriteFile(List<Book>? books);
    internal void DeleteFromFile(Guid? bookId);
}


internal class FileBookRepository(string path) : IBookRepository
{
    private string _path = path;
    //private readonly IBookRepository _bookRepository;
    public List<Book>? ReadFile()
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

    public void AddToFile(Book book)
    {
        var books = ReadFile();
        
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

    public void WriteFile(List<Book>? books)
    {
        var jsonWrite = JsonConvert.SerializeObject(books, Formatting.Indented);
        File.WriteAllText(_path, jsonWrite);
    }

    public void DeleteFromFile(Guid? bookId)
    {
        var books = ReadFile();
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
        WriteFile(books);
    }
}