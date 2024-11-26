public class ErrorResult : Result
{
    public ErrorModel Error { get; set; }
    public ErrorResult(ErrorModel error) : base(false)
    {
        Error = error;
    }

}

public class ErrorResult<T> : Result<T>
{
    public ErrorModel Error { get; set; }
    public ErrorResult(ErrorModel error) : base(false, default)
    {
        Error = error;
    }

}