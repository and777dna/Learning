namespace LIBRARY;

/*public interface IValidation
{
    void Notify();
}

public class JsonValidation : IValidation
{
    public void Notify()
    {
        throw new KeyNotFoundException($"Book not found");
    }
}

public class SearchValidation : IValidation
{
    public void Notify()
    {
        throw new KeyNotFoundException($"Book not found");
    }
}

public class ValidationManager()
{
    public readonly IValidation _validation;

    public ValidationManager(IValidation validation)
    {
        _validation = validation;
    }
}*/
public static class JsonValidation
{
    internal static void JsonValidate(List<Book>? books)
    {
        if(books == null){throw new KeyNotFoundException($"Book not found");}//TODO: this one exception is wrong
    }
    
    internal static void SearchValidate(Book? book)
    {
        if (book == null) { throw new KeyNotFoundException($"Book not found"); }
    }
}