namespace LIBRARY.Result;

public class Result
{
    public bool IsSuccess {get; }
    public string? Error {get; }
    
    private Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, null);
    public static Result Failure(string error) => new Result(false, error);

}

public class Result<T>// : Result
{
    public bool IsSuccess { get; }
    //public T _value { get; set; }
    private readonly T? _value;
    private string? Error { get; }
    private Result(bool isSuccess, T value, string error)//TODO: maybe to leave only value here?
    {
        IsSuccess = isSuccess;
        _value = value;
        Error = error;
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

    public static Result<T> Failure(string error)
    {
        return new Result<T>(false, default , error);
    }

}