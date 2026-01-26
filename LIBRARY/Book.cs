using LIBRARY;

namespace Library;

public class Book//Library.Book.Book.BookData
{
    public string Author {get; private set;}
    public string Name {get; private set;}//this is a property
    public int Year {get; private set;}

    private int _borrowingCount = 0;
    private string _borrowDate = "";
    private string _borrowReturn = "";

    public string BorrowReturn
    {
        set
        {
            _borrowReturn = value;
        }
    }

    public string SetBorrowDate
    {
        set
        {
            _borrowDate = value;
        }
    }

    public int BorrowingCount
    {
        set//TODO: why private set is not working
        {
            if (value >= 0)
            {
                _borrowingCount = value;
            }
        }
        get
        {
            return _borrowingCount;
        }
    }
  
    
    public Book(string author, string name, int year)
    {
        Author = author;
        Name = name;
        Year = year;
    }

    internal static void CreateBook(Book book)
    {
        Json.AddToJsonFile(book);
    }
    
    internal static void DeleteBook(string searchType, string name = "", string author = "", int year = 0)
    {
        var findedBookToDelete = GetBook(searchType: "name", name, author, year);
        Utils.SearchValidation(findedBookToDelete);
        Json.DeleteFromJsonFile(findedBookToDelete);
    }
    
    internal static void UpdateBook(Book book, string updateParameter = "name", string name = "", string author = "", int year = 0, string borrowDate = "", string borrowReturn = "")
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
    
    internal static Book? GetBook(string searchType = "name", string name = "", string author = "", int year = 0)
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
}