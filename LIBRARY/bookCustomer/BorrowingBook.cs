using Library.Book;

namespace Library.bookCustomer;

public class BorrowingBook
{
    //Book.GettingBook.GetBook(searchType: "name", name, author, year);

    internal static void BorrowBook(Book.Book book)
    {
        /*var findedBookToBorrow = GettingBook.GetBook(book.Name);

        findedBookToBorrow.BorrowingCount += 1;*/
        //UpdatingBook.UpdateBook(book, updateParameter: "borrowingCount", borrowingCount: book.BorrowingCount+=1);
        UpdatingBook.UpdateBook(book, updateParameter: "borrowingCount");

        //RefreshBook()
        //refreshBook, setBorrowDate, set
    }
}