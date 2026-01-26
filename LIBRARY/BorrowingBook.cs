using System.ComponentModel.DataAnnotations;
using Library;

namespace LIBRARY;

public static class BorrowingBook
{
    internal static void BorrowBook(Book book)
    {
        var currentDate = Utils.ExtractDate();
        Book.UpdateBook(book, updateParameter: "borrowingCount", borrowDate: currentDate);
    }
    
    public static void BorrowingFrequencySort()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        var books = Json.ReadJsonFile(filePath);
        if(books == null){throw new ValidationException("no books were found");}
        IEnumerable<Book> sortedBooksByFrequency = Utils.Sort(books);
        Utils.PrintoutBooks(sortedBooksByFrequency);
    }
    
    public static void ReturnBook(Book book)
    {
        string currentDate = Utils.ExtractDate();
        
        Book.UpdateBook(book, updateParameter: "borrowingReturn", borrowReturn: currentDate);
    }
}