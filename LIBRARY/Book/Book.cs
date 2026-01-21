namespace Library.Book;
using AddToJSONClass = Library.customJSONutils.AddToJson;
public class Book//Library.Book.Book.BookData
{
    internal class BookData
    {//Author, Name, Year
        public string Author {get; set;}//TODO: to implement encapsulation here instead of this
        public string Name {get; set;}
        public int Year {get; set;}
    }
    //var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
    internal static void CreateBook(BookData book)
    {
        AddToJSONClass.AddToJsonFile(book);
    }

    internal void DeleteBook(BookData book)
    {
        
    }
}