using LIBRARY.BookFolder;
using LIBRARY.Enums;
using LIBRARY.Logging;

namespace LIBRARY
{
   internal class Program
   {
      public static void Main()
      {
         string _path = Path.Combine(AppContext.BaseDirectory, "books.json");
         ILogger loggerInfoMessages = new InfoLogger();
         ILogger loggerDebugMessages = new DebugLogger();
         
         var loggerForConsole = new Logger(loggerInfoMessages);

         IBookRepository BookOperationsClass = new FileBookRepository(_path);
         var books = BookOperationsClass.Read();
         var BookServiceClass = new BookService(BookOperationsClass, loggerInfoMessages);
         BookServiceClass.PrintoutBooks(books);
         
         
         var SqlBookRepositoryClass = new SqlBookRepository(loggerForConsole);

         var result = BookServiceClass.GetBookForPublic(SearchType.Author, author: "Lev Tolstoy");
         Console.WriteLine("result._value:" + result.Value);

         //SqlBookRepositoryClass.Read();
         //BookServiceClass.GetBookForPublic(name: "Lev Tolstoy");
         
         loggerForConsole.Logging(result.IsSuccess.ToString());

         
         var bookss = (IEnumerable<Book>)result.Value; // явное приведение
         var firstBook = bookss.FirstOrDefault();
         Console.WriteLine(firstBook?.Author + firstBook?.Name);

         /*foreach (var b in result.Value)
         {
            Console.WriteLine(b.);
         }*/
         
         //loggerForConsole.Logging(result._value);
      }
      

        
      }
   
}