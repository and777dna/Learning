namespace Library.customJSONutils;

public class DeleteFromJSON
{
    //internal static void DeleteFromJsonFile(string name)
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