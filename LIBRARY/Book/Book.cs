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
    
    internal static void DeleteBook(string searchType, string name = "", string author = "", int year = 0)
    {
        var findedBookToDelete = GettingBook.GetBook(searchType: "name", name, author, year);
        //Console.WriteLine("findedBookToDelete " + findedBookToDelete.Author + findedBookToDelete.Year + findedBookToDelete.Name);
        DeleteFromJSON.DeleteFromJsonFile(findedBookToDelete);
    }
}