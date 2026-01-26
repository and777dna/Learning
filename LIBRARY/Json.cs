//namespace Library.customJSONutils;

using LIBRARY;
using Newtonsoft.Json;
namespace Library;

public static class Json//Library.customJSONutils.ReadJson
{
    internal static List<Book>? ReadJsonFile(string path)
    {
        using var r = new StreamReader(path);
        var jsonRead = r.ReadToEnd();
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonRead);
        Utils.JsonValidation(books);
        return books;
    }
    
    internal static void AddToJsonFile(Book book)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");

        //List<Book>? books = ReadJsonFile(filePath);
        var books = ReadJsonFile(filePath);

        Utils.CheckUnique(book.Name);
        
        books?.Add(book);
        WriteJsonFile(filePath, books);
        
    }

    internal static void WriteJsonFile(string path, List<Book>? books)
    {
        var jsonWrite = JsonConvert.SerializeObject(books, Formatting.Indented);
        File.WriteAllText(path, jsonWrite);
    }
    
    internal static void DeleteFromJsonFile(Book? book)
    {
        
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        var books = ReadJsonFile(filePath);
        
        var findedBookToDelete = books?.Find(bookDatabase => bookDatabase.Name == book?.Name);
        if (findedBookToDelete == null) return;
        books?.Remove(findedBookToDelete);
        WriteJsonFile(filePath, books);
    }
}