using System.ComponentModel.DataAnnotations;
using Library;

namespace LIBRARY;

public class Utils
{
    internal static string ExtractDate()
    {
        var currentDateWithZeroTime = DateTime.Today;
        var date = currentDateWithZeroTime.ToString().Split()[0];
        return date;
        
    }

    internal static IEnumerable<Book> Sort(List<Book> books)
    {
        return books.OrderBy(book => book.BorrowingCount);;
    }

    internal static void PrintoutBooks(IEnumerable<Book> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine("{0} - {1}", book.Name, book.BorrowingCount);
        }
    }

    internal static void CheckUnique(string nameOfBook)
    {
        var findedBook = Book.GetBook(name: nameOfBook);
        if (findedBook != null)
        {
            throw new ValidationException("book is not original");
        }
    }

    internal static void JsonValidation(List<Book>? books)
    {
        if(books == null){throw new ValidationException("no books were found");}
    }
    
    internal static void SearchValidation(Book? book)
    {
        if (book == null) { throw new ValidationException("no books or searched book were found"); }
    }
}