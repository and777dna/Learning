using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBRARY;

[Table("reader")]
public class Reader
{
    [Column("name")]
    public readonly string Name;
    [Key]
    public readonly Guid TicketNumber;
    [Column("phoneNumber")]
    public readonly int PhoneNumber;

    public List<Guid>? _borrowedBooks { get; } = new List<Guid>(3);
    public List<Guid>? _historyOfCheckOuts { get; } = new List<Guid>();
    
    //CurrenCheckoutBook
    /*public Guid CurrentCheckOutBook
    {
        get => _currenCheckOutBook;
        set => _currenCheckOutBook = value;
    }*/

    public Reader(string name, int phoneNumber, Guid ticketNumber)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        PhoneNumber = phoneNumber;
        TicketNumber = ticketNumber;
    }
    
    /*public List<Guid> BorrowedBooks
    {
        get => _borrowedBooks;
        set => _borrowedBooks.Count < 3 ? _borrowedBooks.Add(value) : Console.WriteLine("no checkout for more than 3 books per hand.");
    }*/
    
}