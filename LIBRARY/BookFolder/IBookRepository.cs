namespace LIBRARY.BookFolder;

public delegate void UpdateDelegate<TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter);

internal interface IBookRepository
{
    public List<Book> Read();//Non-abstract and non-extern method must declare a body
    //internal void AddToFile(Book book);//Non-public method 'ReadJsonFile' cannot implement method from interface IBookRepository
    internal void Create(Book book);
    internal Result.Result Delete(Guid bookId);
    public Result.Result UpdateField<TUpdateParameter>(Guid bookId, TUpdateParameter updateParameter, UpdateDelegate<TUpdateParameter> up);
}