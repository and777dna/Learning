using Library.customJSONutils;

namespace Library.Book;

public class UpdatingBook
{
    internal static void UpdateBook(Book book, string updateParameter = "name", string name = "", string author = "", int year = 0, string borrowDate = "")
    {
        /*Console.WriteLine("UpdateBook" + book.Name + book.Author);
        var findedBookToUpdate = GettingBook.GetBook(name: book.Name);
        Console.WriteLine("findedBookToUpdate" + findedBookToUpdate.Name);
        switch(updateParameter)//TODO: to add validation
        {
            case "name": findedBookToUpdate.Name = name; break;
            case "author": findedBookToUpdate.Author = author; break;
            case "year": findedBookToUpdate.Year = year; break;
            case "borrowingCount": findedBookToUpdate.BorrowingCount = borrowingCount; break;
            default: findedBookToUpdate = null; break;//TODO: to fix this
        }*/
        
        var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
        List<Book> books = Json.ReadJsonFile(filePath);
        Console.WriteLine("books.Count before:" + books.Count);
        //var findedBookToUpdateInsideJSON = 
        /*books.Find(bookDatabase =>
        {
            if (bookDatabase.Name == book.Name)//TODO: to write this function distinctly
            {
                bookDatabase.Author = book.Author;
            }

            return true;
            //return bookDatabase.Name == findedBookToUpdate.Name;
        });*/
        var findedBookToUpdate = books.Find(bookDatabase => bookDatabase.Author == book.Author);
        switch(updateParameter)//TODO: to add validation
        {
            case "name": findedBookToUpdate.Name = name; break;
            case "author": findedBookToUpdate.Author = author; break;
            case "year": findedBookToUpdate.Year = year; break;
            case "borrowingCount": findedBookToUpdate.BorrowingCount += 1;
                findedBookToUpdate.SetBorrowDate = borrowDate; Console.WriteLine("returnDate:" + borrowDate.GetType()); break;
            default: findedBookToUpdate = null; break;//TODO: to fix this
        }
        
        Console.WriteLine("books.Count after:" + books.Count + " books[0].BorrowingCount:" + books[0].BorrowingCount );
        
        
        Json.WriteJsonFile(filePath, books);
    }
}