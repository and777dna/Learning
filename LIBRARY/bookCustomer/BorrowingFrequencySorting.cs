using Library.customJSONutils;

namespace Library.bookCustomer;

public class BorrowingFrequencySorting
{
    public static void BorrowingFrequencySort()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        List<Book.Book> books = Json.ReadJsonFile(filePath);
        IEnumerable<Book.Book> sortedBooksByFrequency = books.OrderBy(book => book.BorrowingCount);
        
        foreach (Book.Book book in sortedBooksByFrequency)
        {
            Console.WriteLine("{0} - {1}", book.Name, book.BorrowingCount);
        }
    }
}