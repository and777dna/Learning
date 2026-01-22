using Library.customJSONutils;

namespace Library.Book;
using AddToJSONClass = Library.customJSONutils.AddToJson;
public class Book//Library.Book.Book.BookData
{
    public string Author {get; set;}//TODO: to implement encapsulation here instead of this??
    public string Name {get; set;}//this is a property
    public int Year {get; set;}
    public Book(string author, string name, int year)//this is a constructor
    {
        Author = author;
        Name = name;
        Year = year;
    }
    /*internal class BookData
    {//Author, Name, Year
        public string Author {get; set;}//TODO: to implement encapsulation here instead of this??
        public string Name {get; set;}
        public int Year {get; set;}
    }*/
    //var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
    internal static void CreateBook(Book book)
    {
        AddToJSONClass.AddToJsonFile(book);
    }

    //internal static void DeleteBook(Book book, string nameOfBook)
    internal static void DeleteBook(string name)
    {
        
        /*var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        List<Book> books = Json.ReadJsonFile(filePath);
        Console.WriteLine("books.Count before:" + books.Count);
        var findedBookToDelete = books.Find(book => book.Name == name);
        books.Remove(findedBookToDelete);
        
        Json.WriteJsonFile(filePath, books);*/
        DeleteFromJSON.DeleteFromJsonFile(name);
    }
}