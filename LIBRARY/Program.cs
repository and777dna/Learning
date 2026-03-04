using LIBRARY.BookFolder;
using LIBRARY.Enums;
using LIBRARY.Logging;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LIBRARY
{
   internal class Program
   {
      public static void Main()
      {
         string _path = Path.Combine(AppContext.BaseDirectory, "books.json");
         ILogger logger = new Logger();
         

         var fileBookRepositoryClass = new FileBookRepository(_path, logger);
         
         var books = fileBookRepositoryClass.Books;
         
         var BookServiceClass = new BookService(fileBookRepositoryClass, logger);
         BookServiceClass.PrintoutBooks(books);
         
         
         var SqlBookRepositoryClass = new SqlBookRepository(logger);

         var result = BookServiceClass.GetBookForPublic(SearchType.Author, author: "Lev Tolstoy");
         Console.WriteLine("result._value:" + result.Value);

         //SqlBookRepositoryClass.Read();
         //BookServiceClass.GetBookForPublic(name: "Lev Tolstoy");
         
         logger.DebugLogger(result.IsSuccess.ToString());

         
         var bookss = (IEnumerable<Book>)result.Value; // явное приведение
         var firstBook = bookss.FirstOrDefault();
         Console.WriteLine(firstBook?.Author + firstBook?.Name);

         
         
         var BookRepositoryClass = new FileBookRepository(_path, logger);
         var bookId = books[0].BookId;
         BookRepositoryClass.UpdateField(bookId, "Waar and peace", BookRepositoryClass.UpdateName);
         /*foreach (var b in result.Value)
         {
            Console.WriteLine(b.);
         }*/
         
         //loggerForConsole.Logging(result._value);
      }
      

        
      }
   
}