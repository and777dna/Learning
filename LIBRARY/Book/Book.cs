using Library.customJSONutils;

namespace Library.Book;
using AddToJSONClass = Library.customJSONutils.AddToJson;
public class Book//Library.Book.Book.BookData
{
    public string Author {get; set;}//TODO: to implement encapsulation here instead of this??
    public string Name {get; set;}//this is a property
    public int Year {get; set;}

    private int _borrowingCount = 0;
    private string _borrowDate = "";
    private string _borrowReturn { get; set; } = "";

    public string SetBorrowDate
    {
        set
        {
            _borrowDate = value;
            /*string dayToReturn = (Int32.Parse(value.Split(".")[0]) + 5).ToString();
            var arrayWithDate = value.Split(".");
            arrayWithDate[0] = dayToReturn;
            _borrowReturn = arrayWithDate.Join(".");*/
        }
        get
        {
            return _borrowDate;
        }
    }

    public int BorrowingCount
    {
        set
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
        AddToJSONClass.AddToJsonFile(book);
    }
    
    internal static void DeleteBook(string searchType, string name = "", string author = "", int year = 0)
    {
        var findedBookToDelete = GettingBook.GetBook(searchType: "name", name, author, year);
        //Console.WriteLine("findedBookToDelete " + findedBookToDelete.Author + findedBookToDelete.Year + findedBookToDelete.Name);
        DeleteFromJSON.DeleteFromJsonFile(findedBookToDelete);
    }
}