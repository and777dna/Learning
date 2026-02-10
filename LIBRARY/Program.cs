using LIBRARY.BookFolder;
using LIBRARY.Enums;

namespace LIBRARY
{
   internal class Program
   {
      public static void Main()
      {
         //var book1 = new BookClassAddBook("Mikhail Sholokhov", "The Quiet Don", 1925);//TODO: to create ID for each book
         //TODO: to create validation if book already exist in .json
         //var findedBook = GettingBook.GetBook(searchType: "name", name: "The Quiet Don");
         //Console.WriteLine("findedBook:" + findedBook.Author + "-" + findedBook.Name + "-" + findedBook.Year);
         /*var book1  = new Book("Lev Tolstoy", "War and Peace", 1869);
         var book2  = new Book("Lev Tolstoy", "Anna Karenina", 1877);
         var book3  = new Book("Fyodor Dostoevsky", "Crime and Punishment", 1866);
         var book4  = new Book("Fyodor Dostoevsky", "The Brothers Karamazov", 1880);
         var book5  = new Book("Nikolai Gogol", "Dead Souls", 1842);
         var book6  = new Book("Alexander Pushkin", "Eugene Onegin", 1833);
         var book7  = new Book("Ivan Turgenev", "Fathers and Sons", 1862);
         var book8  = new Book("Anton Chekhov", "The Cherry Orchard", 1904);
         var book9  = new Book("Boris Pasternak", "Doctor Zhivago", 1957);
         var book10 = new Book("Aleksandr Solzhenitsyn", "One Day in the Life of Ivan Denisovich", 1962);
         var book11 = new Book("Mikhail Bulgakov", "The Master and Margarita", 1967);
         var book12 = new Book("Ivan Goncharov", "Oblomov", 1859);
         var book13 = new Book("Mikhail Lermontov", "A Hero of Our Time", 1840);
         var book14 = new Book("Fyodor Dostoevsky", "The Idiot", 1869);
         var book15 = new Book("Fyodor Dostoevsky", "Notes from Underground", 1864);
         var book16 = new Book("Leo Tolstoy", "Resurrection", 1899);
         var book17 = new Book("Alexander Pushkin", "The Captain's Daughter", 1836);
         var book18 = new Book("Nikolai Gogol", "Taras Bulba", 1835);
         var book19 = new Book("Yevgeny Zamyatin", "We", 1924);
         
         var books = BookRepository.ReadJsonFile();
         var library = new BookService(books);
         library.AddBookToLibrary(book1);
         library.AddBookToLibrary(book2);
         library.AddBookToLibrary(book3);
         library.AddBookToLibrary(book4);
         library.AddBookToLibrary(book5);
         library.AddBookToLibrary(book6);
         library.AddBookToLibrary(book7);
         library.AddBookToLibrary(book8);
         library.AddBookToLibrary(book9);
         library.AddBookToLibrary(book10);
         library.AddBookToLibrary(book11);
         library.AddBookToLibrary(book12);
         library.AddBookToLibrary(book13);
         library.AddBookToLibrary(book14);
         library.AddBookToLibrary(book15);
         library.AddBookToLibrary(book16);
         library.AddBookToLibrary(book17);
         library.AddBookToLibrary(book18);
         library.AddBookToLibrary(book19);*/
         //var reader1 = new Reader("andrei", 731802095, Guid.NewGuid());
         //var reader2 = new Reader("nikol", 888333999, Guid.NewGuid());
         //AddReader
         //var readers = ReaderRepository.ReadJsonFile();
         //var readerServiceClass = new ReaderService(readers);
         //readerServiceClass.AddReader(reader1);
         //readerServiceClass.AddReader(reader2);
         //var bookId = new Guid("9f936252-39e6-424b-9071-eed68781e874");//TODO:uncomment
         /*var readerId = new Guid("e335fd57-6278-4193-9eca-e89d15dc9c0f");
         var book1Id = new Guid("9f936252-39e6-424b-9071-eed68781e874");
         var book2Id = new Guid("bc2a69e4-c9dd-4308-a1bc-5b78b4d0cfb1");
         var book3Id = new Guid("7dd82460-7b84-4144-bcbd-d3db5ed07819");
         var book4Id = new Guid("530569cd-a095-4dd4-acd7-887e45817aa2");
         //var readerId = reader1.TicketNumber;
         
         var borrowingBookClass = new BorrowingBook();*/
         //borrowingBookClass.ReturnBook(bookId, readerId);
         /*borrowingBookClass.BorrowBook(book1Id, readerId);
         borrowingBookClass.BorrowBook(book2Id, readerId);
         borrowingBookClass.BorrowBook(book3Id, readerId);
         borrowingBookClass.BorrowBook(book4Id, readerId);*/
         /*borrowingBookClass.ReturnBook(book1Id, readerId);
         borrowingBookClass.ReturnBook(book2Id, readerId);
         borrowingBookClass.ReturnBook(book3Id, readerId);
         borrowingBookClass.ReturnBook(book4Id, readerId);*/
         /*var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
         var books = BookRepository.ReadJsonFile();
         var library = new BookService(books);*/

         //var book1 = library.GetBook( searchType: "name", name: "dfvdf");
         //if(book1 == null){Console.WriteLine("book1 == null");}
         //BorrowingBook.BorrowBook(book1);
         //BookClassAddBook.DeleteBook("name", "The Quiet Don");
         //BookClassAddBook.CreateBook(book1);
         //UpdatingBook.UpdateBook(book1, updateParameter: "name", name: "The Quiet Don");
         //var book1 = Book.GetBook( searchType: "author", author: "Mikhail Lermontov");
         //BorrowingBook.ReturnBook(book1);
         //BorrowingBook.BorrowBook(book1);
         
         string _path = Path.Combine(AppContext.BaseDirectory, "books.json");

         IBookRepository BookOperationsClass = new FileBookRepository(_path);
         var books = BookOperationsClass.Read();
         var BookServiceClass = new BookService(BookOperationsClass);
         BookServiceClass.PrintoutBooks(books);

         var SqlBookRepositoryClass = new SqlBookRepository();
         var book = new Book("Fyodor Dostoevsky", "Crime and Punishment", 1866, Genre.History);
         var book1 = new Book("Mikhail Sholokhov", "The Quiet Don", 1925, Genre.History);
         Console.WriteLine(book.Name);
         //SqlBookRepositoryClass.Create(book);
         //SqlBookRepositoryClass.Create(book1);
         //SqlBookRepositoryClass.Delete((Guid)54c092dc-1c34-4a80-8648-1d4567312d39);
         //SqlBookRepositoryClass.Delete(Guid.Parse("5a2ee767-ec35-435c-96d0-2431bf331653"));
         SqlBookRepositoryClass.Update(Guid.Parse("d92ea08b-d253-44b4-803c-d89451ab83ef"), "fff", UpdateParameter.Name);
         //BookServiceClass.GetBookForPublic(name: "Lev Tolstoy");
         /*ILogger loggerMessages = new ConsoleLogger();
         var loggerForConsole = new Logger(loggerMessages);
         loggerForConsole.Logging("asdf");*/
      }
      

        
      }
   
}