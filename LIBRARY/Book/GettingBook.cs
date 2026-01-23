using System.Diagnostics;

namespace Library.Book;

public class GettingBook
{
    internal static Book GetBook(string searchType = "name", string name = "", string author = "", int year = 0)
    {
        Book findedBook;
        Console.WriteLine("GetBook:" + searchType + name);
        switch(searchType)//TODO: to add validation
        {
            case "name": findedBook = SearchingBook.NameSearch(name); break;
            case "author": findedBook = SearchingBook.AuthorSeach(author); break;
            case "year": findedBook = SearchingBook.YearSearch(year); break;
            default: findedBook = null; break;
        }
        Console.WriteLine("GetBook findedBook:" + findedBook.Name + findedBook.Author);
        return findedBook;
    }
}