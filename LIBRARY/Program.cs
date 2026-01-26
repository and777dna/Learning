
namespace Library
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

         Book.CreateBook(book1);
         Book.CreateBook(book2);
         Book.CreateBook(book3);
         Book.CreateBook(book4);
         Book.CreateBook(book5);
         Book.CreateBook(book6);
         Book.CreateBook(book7);
         Book.CreateBook(book8);
         Book.CreateBook(book9);
         Book.CreateBook(book10);
         Book.CreateBook(book11);
         Book.CreateBook(book12);
         Book.CreateBook(book13);
         Book.CreateBook(book14);
         Book.CreateBook(book15);
         Book.CreateBook(book16);
         Book.CreateBook(book17);
         Book.CreateBook(book18);
         Book.CreateBook(book19);*/

         var book1 = Book.GetBook( searchType: "name", name: "dfvdf");
         if(book1 == null){Console.WriteLine("book1 == null");}
         //BorrowingBook.BorrowBook(book1);
         //BookClassAddBook.DeleteBook("name", "The Quiet Don");
         //BookClassAddBook.CreateBook(book1);
         //UpdatingBook.UpdateBook(book1, updateParameter: "name", name: "The Quiet Don");
         //var book1 = Book.GetBook( searchType: "author", author: "Mikhail Lermontov");
         //BorrowingBook.ReturnBook(book1);
         //BorrowingBook.BorrowBook(book1);
      }
      

        
      }
   
}