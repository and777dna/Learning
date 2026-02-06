using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LIBRARY.Enums;

namespace LIBRARY;

[Table("book")]
public class Book
{
    //private readonly Guid _bookId;
    
    [Key]
    public Guid BookId { get; set; } = Guid.NewGuid();
    //public readonly Guid BookId = _bookId;
    
    [Column("author")]
    public string Author {get; set;}
    [Column("name")]
    public string Name {get; set;}
    [Column("year")]
    public int Year {get; set;}
    [Column("genre")]
    public Genre BookGenre { get; set; }

    [Column("borrowingCount")]
    private int _borrowingCount = 0;
    [Column("borrowDate")]
    private DateTime _borrowDate;
    [Column("returnDate")]
    private DateTime _returnDate;
    
    private bool _bookIsCheckOut;
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


    public Book() {}
    public Book(string author, string name, int year, Genre bookGenre )
    {
        Author = author ?? throw new ArgumentNullException(nameof(author));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Year = year;
        BookGenre = bookGenre; // ?? throw new ArgumentNullException(nameof(bookGenre));
    }

    
}