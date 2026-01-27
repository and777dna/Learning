using Library;

namespace LIBRARY;

public class BookService(List<Book> books)
{
    //List<>
    public List<Book> Books { get; set; } = books;

    internal void CreateBook(Book book)
    {
        Json.AddToJsonFile(book);
    }
    
    internal void DeleteBook(string searchType, string name = "", string author = "", int year = 0)
    {
        var findedBookToDelete = GetBook(searchType: "name", name, author, year);
        Utils.SearchValidation(findedBookToDelete);
        Json.DeleteFromJsonFile(findedBookToDelete);
    }
    
    internal void UpdateBook(Book book, string updateParameter = "name", string name = "", string author = "", int year = 0, string borrowDate = "", string borrowReturn = "")
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        var books = Json.ReadJsonFile(filePath);
        
        var findedBookToUpdate = books?.Find(bookDatabase => bookDatabase.Author == book.Author);
        Utils.SearchValidation(findedBookToUpdate);
        switch(updateParameter)//TODO: to add validation
        {
            case "name": findedBookToUpdate.Name = name; break;
            case "author": findedBookToUpdate.Author = author; break;
            case "year": findedBookToUpdate.Year = year; break;
            case "borrowingCount": findedBookToUpdate.BorrowingCount += 1;
                findedBookToUpdate.SetBorrowDate = borrowDate; Console.WriteLine("returnDate:" + borrowDate.GetType()); break;
            case "borrowingReturn": findedBookToUpdate.BorrowReturn = borrowReturn; break;
            default: throw new ArgumentException("you typed in the wrong argument");
        }
        
        Json.WriteJsonFile(filePath, books);
    }
    
    internal Book? GetBook(string searchType = "name", string name = "", string author = "", int year = 0)
    {
        Book? findedBook;
        Console.WriteLine("GetBook:" + searchType + " " + name);
        switch(searchType)//TODO: to add validation
        {
            case "name": findedBook = SearchingBook.NameSearch(name); break;
            case "author": findedBook = SearchingBook.AuthorSeach(author); break;
            case "year": findedBook = SearchingBook.YearSearch(year); break;
            default: findedBook = null; break;
        }
        Console.WriteLine("GetBook findedBook:" + findedBook?.Name + findedBook?.Author);
        return findedBook;
    }
    
    internal static void PrintoutBooks(IEnumerable<Book> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine("{0} - {1}", book.Name, book.BorrowingCount);
        }
    }
    
    
}