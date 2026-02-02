using System.Collections;
using System.Data;

namespace LIBRARY;

public enum SearchType{
    Name,
    Year,
    Author,
    Genre
}

public enum UpdateParameter{
    Name,
    Year,
    Author,
    BorrowingBook,
    ReturningBook
}

public enum Genre{
    Fiction,
    Science,
    History,
    Philosophy,
    Poetry
}

public class BookService(List<Book>? books)
{
    public List<Book> Books { get; set; } = books;

    internal void AddBookToLibrary(Book book)
    {
        BookRepository.AddToJsonFile(book);
    }
    
    //TODO: IDNEW
    internal void DeleteBook(Guid? bookId)
    {
        if (bookId == null)
        {
            throw new ArgumentNullException(nameof(bookId));
        }
        BookRepository.DeleteFromJsonFile(bookId);
    }
    
    internal Guid? FindBookId(string? name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        var books = BookRepository.ReadJsonFile();
        if (books == null)
        {
            throw new FileNotFoundException();
            
        }
        var id = SearchByNameToId(name, books);
        return id;
    }
    
    internal Guid? SearchByNameToId(string? name, List<Book>? books)
    {
        if (name == null || books == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        var findedBook = books.Find(book => book.Name == name);
        if (findedBook == null)
        {
            throw new KeyNotFoundException();
        }
        return findedBook.BookId;
    }

    internal Book? SearchById(Guid bookId, List<Book> books)
    {
        var findedBook = books?.Find(book => book.BookId == bookId);
        return findedBook;
    }
    
    internal void UpdateBook(Guid bookId, UpdateParameter updateParameter = UpdateParameter.Name, string name = "", string author = "", int year = 0, DateTime borrowDate = new DateTime(), DateTime returnDate = new DateTime())
    {
        var books = BookRepository.ReadJsonFile();
        
        var findedBookToUpdate = books?.Find(bookDatabase => bookDatabase.BookId == bookId);
        JsonValidation.SearchValidate(findedBookToUpdate);
        switch(updateParameter)//TODO: to add validation
        {
            case UpdateParameter.Name: findedBookToUpdate.Name = name; break;
            case UpdateParameter.Author: findedBookToUpdate.Author = author; break;
            case UpdateParameter.Year: findedBookToUpdate.Year = year; break;
            case UpdateParameter.BorrowingBook:
                if (findedBookToUpdate.BookIsCheckout)
                {
                    throw new ConstraintException("the book is already checkout");
                }
                findedBookToUpdate.BorrowingCount += 1;
                findedBookToUpdate.BookIsCheckout = true;
                findedBookToUpdate.BorrowDate = borrowDate; Console.WriteLine("returnDate:" + borrowDate.GetType()); 
                break;
            case UpdateParameter.ReturningBook: 
                if (findedBookToUpdate.BookIsCheckout == false)
                {
                    throw new ConstraintException("the book is not checkout");
                }
                findedBookToUpdate.ReturnDate = returnDate;
                findedBookToUpdate.BookIsCheckout = false;
                break;
            default: throw new ArgumentException("you typed in the wrong argument");
        }
        
        BookRepository.WriteJsonFile(books);
    }
    
    internal Book? GetBookById(Guid bookId)
    {
        var books = BookRepository.ReadJsonFile();
        
        var findedBook = SearchById(bookId, books);
        return findedBook;
    }
    
    internal IEnumerable GetBookForPublic(SearchType searchType = SearchType.Name, string name = "", string author = "", int year = 0, Genre genre = Genre.Fiction)
    {
        Console.WriteLine("GetBook:" + searchType + " " + name);
        
        var books = BookRepository.ReadJsonFile();
        ISearch searchByAuthor = new ByAuthor(books);
        ISearch searchByName = new ByName(books);
        ISearch searchByYear = new ByYear(books);
        ISearch searchByGenre = new ByGenre(books);
        
        switch(searchType)
        {
            case SearchType.Author: 
                var startingSearchByAuthor = new SearchingBookForPublic(searchByAuthor); 
                return startingSearchByAuthor.Search(author);
            case SearchType.Name:
                var startingSearchByName = new SearchingBookForPublic(searchByName); 
                return startingSearchByName.Search(name);
            case SearchType.Year: 
                var startingSearchByYear = new SearchingBookForPublic(searchByYear); 
                return startingSearchByYear.Search(year); 
            case SearchType.Genre:
                var startingSearchByGenre = new SearchingBookForPublic(searchByGenre);
                return startingSearchByGenre.Search(genre);
        }
        return null;
    }
    
    internal void PrintoutBooks(IEnumerable<Book> books)//IEnumerable<Book> books
    {
        foreach (var book in books)
        {
            Console.WriteLine("{0} - {1}", book.Name, book.BorrowingCount);
        }
    }
    
    
}