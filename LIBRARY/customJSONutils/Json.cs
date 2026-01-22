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

    internal static void WriteJsonFile(string path, List<Book.Book> books)
    {
        string jsonWrite = JsonConvert.SerializeObject(books);
        File.WriteAllText(path, jsonWrite);
    }
}