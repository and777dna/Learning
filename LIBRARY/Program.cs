using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Library.Book;

//using BookClass = Library.Book.Book.BookData;
using BookClassAddBook = Library.Book.Book;
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine("vdfv");

namespace Library
{
   internal class Program
   {
      
      public class data
      {
         public int Id { get; set; }
         public int SSN { get; set; }
         public string Message { get; set;}
      }

      public static void Main()
      {

         var book1 = new BookClassAddBook("Mikhail Sholokhov", "The Quiet Don", 1925);//TODO: to create ID for each book
         //var findedBook = GettingBook.GetBook(searchType: "name", name: "The Quiet Don");
         //Console.WriteLine("findedBook:" + findedBook.Author + "-" + findedBook.Name + "-" + findedBook.Year);
         
         //BookClassAddBook.DeleteBook("name", "The Quiet Don");
         //BookClassAddBook.CreateBook(book1);

         //var book2 = new BookClass("Mikhail Lermontov", "A Hero of Our Time", 1840);
         /*public string Author {get; set;}//TODO: to implement encapsulation here instead of this
         public string Name {get; set;}
         public string Year {get; set;}*/
         //BookClassAddBook.CreateBook(book1);
         //BookClassAddBook.CreateBook(book2);

      }
      

        
      }
   
}
/*Консольный проект + json для хранения данных.
   - [CRUD](https://skyeng.ru/magazine/wiki/it-industriya/chto-takoe-crud/) операции (обновить книгу из источника данных)
   
   - Сортировка по популярности (кол-во выдач)
   - Выдача/возврат книг с датами
*/