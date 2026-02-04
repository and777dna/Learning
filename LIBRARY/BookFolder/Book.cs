namespace LIBRARY;

public class Book
{
    public readonly Guid BookId;// = Guid.NewGuid();
    //public readonly Guid BookId = _bookId;
    
    public string Author {get; set;}
    public string Name {get; set;}
    public int Year {get; set;}
    private bool _bookIsCheckOut;
    public Genre BookGenre { get; set; }

    private int _borrowingCount = 0;
    //private string _borrowDate = "";
    private DateTime _borrowDate;
    private DateTime _returnDate;


    public bool BookIsCheckout
    {
        get => _bookIsCheckOut;
        set => _bookIsCheckOut = value;
    }
    public DateTime ReturnDate
    {
        set
        {
            _returnDate = value;
        }
        get
        {
            return _returnDate;
        }
    }

    public DateTime BorrowDate
    {
        set
        {
            _borrowDate = value;
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
  
    
    public Book(string author, string name, int year, Guid bookId, Genre bookGenre )
    {
        Author = author ?? throw new ArgumentNullException(nameof(author));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Year = year;
        BookId = bookId;
        BookGenre = bookGenre; // ?? throw new ArgumentNullException(nameof(bookGenre));
    }

    
}