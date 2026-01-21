using System.Text.Json;

using BookClass = Library.Book.Book.BookData;

using ReadJsonClass = Library.customJSONutils.ReadJson;

namespace Library.customJSONutils;

public static class AddToJson//Library.customJSONutils.AddToJSON
{
    internal static void AddToJsonFile(BookClass book)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");

        var jsonContent = ReadJsonClass.ReadJsonFile(filePath);
        Console.WriteLine("jsonContent:" + jsonContent);
        //var initialJson = filePath;
        //var array = JArray.Parse(initialJson);
        //var list = JsonConvert.DeserializeObject<List<Person>>(myJsonString);
        
        
        string json = JsonSerializer.Serialize(book);
        Console.WriteLine("jsonContent+json:"+jsonContent+json);
        //var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        Console.WriteLine("filePath:" + filePath);
        File.WriteAllText(filePath, jsonContent+json);
    }
}