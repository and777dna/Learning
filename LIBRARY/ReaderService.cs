using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LIBRARY;

public class ReaderService(List<Reader>? readers)
{
    public List<Reader> Readers { get; set; } = readers;
    internal Reader? FindReaderById(Guid? ticketNumber)
    {
        foreach (var r in Readers)
        {
            Console.WriteLine("reader:" + r.Name + " " + r.TicketNumber);
        }
        var reader = Readers.Find(reader => reader.TicketNumber == ticketNumber);
        return reader;
    }


    internal void UpdateReader(Guid? ticketNumber, Guid currentCheckOutBook, bool borrowBook = true)
    {
        
            var reader = FindReaderById(ticketNumber);
            if(reader == null) throw new KeyNotFoundException($"Book not found");
            Console.WriteLine("reader:" + reader.Name);
            
            if(borrowBook)reader._historyOfCheckOuts.Add(currentCheckOutBook);
            if (borrowBook)
            {
                if (reader._borrowedBooks.Count < 3)
                {
                    reader._borrowedBooks.Add(currentCheckOutBook); 
                    Console.WriteLine("reader._borrowedBooks.Count:" + reader._borrowedBooks.Count);
                }
                else
                {
                    throw new ValidationException("3 books per user is limit");
                }
            }
            else
            {
                reader._borrowedBooks.Remove(currentCheckOutBook); 
            }
            ReaderRepository.WriteJsonFile(readers);
        
            PrintOutCheckouts(reader._historyOfCheckOuts);
    }

    internal void AddReader(Reader reader)
    {
        ReaderRepository.AddToJsonFile(reader);
    }
    
    public static void PrintOutCheckouts(List<Guid> historyOfCheckOuts)//TODO: to find books according to bookId
    {
        foreach (var checkout in historyOfCheckOuts)
        {
            Console.WriteLine("checkout " + checkout );
        }
    }
}