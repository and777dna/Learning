using LIBRARY.Enums;

namespace LIBRARY.BookFolder;

internal interface IBookRepository
{
    public List<Book> Read();//Non-abstract and non-extern method must declare a body
    //internal void AddToFile(Book book);//Non-public method 'ReadJsonFile' cannot implement method from interface IBookRepository
    internal void Create(Book book);
    //internal void WriteFile(List<Book>? books);//WEWEWEWDFEWRCERC
    internal void Delete(Guid bookId);
    internal void Update(Guid bookId, object paramToChange, UpdateParameter updateParameter = UpdateParameter.Name);
}