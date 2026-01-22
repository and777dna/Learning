namespace Library.customJSONutils;

public class DeleteFromJSON
{
    internal static void DeleteFromJsonFile(string name)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        List<Book.Book> books = Json.ReadJsonFile(filePath);
        Console.WriteLine("books.Count before:" + books.Count);
        var findedBookToDelete = books.Find(book => book.Name == name);
        books.Remove(findedBookToDelete);
        
        Json.WriteJsonFile(filePath, books);
    }
    
}