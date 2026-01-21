using System.Text.Json;

using BookClass = Library.Book.Book.BookData;

namespace Library.customJSONutils;

public class AddToJson//Library.customJSONutils.AddToJSON
{
    internal void AddToJsonFile(BookClass  book)
    {
        string json = JsonSerializer.Serialize(book);
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        Console.WriteLine("filePath:" + filePath);
        File.WriteAllText(filePath, json);
    }
}