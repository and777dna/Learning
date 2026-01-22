using System.Text.Json;
using Newtonsoft.Json;

//using BookClass = Library.Book.Book.BookData;

namespace Library.customJSONutils;

public static class AddToJson//TODO: to use single responsibility here
{
    internal static void AddToJsonFile(Book.Book book)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");

        List<Book.Book> books = Json.ReadJsonFile(filePath);
        
        books.Add(book);//TODO: to create validation to see if i dont have it already

        Json.WriteJsonFile(filePath, books);

    }
}