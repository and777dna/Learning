namespace LIBRARY.Result;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    //public T _value { get; set; }
    private readonly T? _value;
    private object? _error { get; set; }
    private Result(bool isSuccess, T value, object error)//TODO: maybe to leave only value here?
    {
        IsSuccess = isSuccess;
        _value = value;
        _error = error;
    }
    public T Value
    {
        get
        {
            return _value!;
        }
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, null);
    }

    public static Result<T> Failure(object error)
    {
        return new Result<T>(false, default , error);
    }

}