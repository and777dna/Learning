using LIBRARY;

namespace Library;

public class Book//Library.Book.Book.BookData
{
    public string Author {get; set;}
    public string Name {get; set;}//this is a property
    public int Year {get; set;}

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

    
}