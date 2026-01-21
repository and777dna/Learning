namespace Library.Book;
using AddToJSONClass = Library.customJSONutils.AddToJson;
public class Book
{
    internal class BookData
    {//Author, Name, Year
        public string Author {get; set;}//TODO: to implement encapsulation here instead of this
        public string Name {get; set;}
        public string Year {get; set;}
    }
    //var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
    internal void CreateBook(BookData book)
    {
        AddToJSONClass.AddToJsonFile(book);
    }
    
    internal void DeleteBook(BookData book){}
}