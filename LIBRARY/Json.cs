namespace Library.customJSONutils;
using Newtonsoft.Json;

public class Json//Library.customJSONutils.ReadJson
{
    internal static List<Book.Book> ReadJsonFile(string path)
    {
        List<Book.Book> books;
        using (StreamReader r = new StreamReader(path))
        {
            string jsonRead = r.ReadToEnd();
            books = JsonConvert.DeserializeObject<List<Book.Book>>(jsonRead);
        }

        return books;
    }
    
    internal static void AddToJsonFile(Book.Book book)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");

        List<Book.Book> books = Json.ReadJsonFile(filePath);
        
        books.Add(book);//TODO: to create validation to see if i dont have it already

        Json.WriteJsonFile(filePath, books);

    }

    internal static void WriteJsonFile(string path, List<Book.Book> books)
    {
        string jsonWrite = JsonConvert.SerializeObject(books);
        File.WriteAllText(path, jsonWrite);
    }
    
    internal static void DeleteFromJsonFile(Book.Book book)
    {
        Console.WriteLine("findedBookToDelete:" + book.Author + book.Year + book.Name);
        
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        List<Book.Book> books = Json.ReadJsonFile(filePath);
        Console.WriteLine("books.Count before:" + books.Count);
        var findedBookToDelete = books.Find(bookDatabase => bookDatabase.Name == book.Name);
        //books.Remove(findedBookToDelete);
        books.Remove(findedBookToDelete);
        Console.WriteLine("books.Count before:" + books.Count);
        
        Json.WriteJsonFile(filePath, books);
    }
}