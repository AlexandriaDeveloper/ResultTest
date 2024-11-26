public class SuccessResult : Result
{
    public string Message { get; set; }
    public SuccessResult() : base(true) { }
    public SuccessResult(string message) : base(true)
    {
        Message = message;
    }
}
public class SuccessResult<T> : Result<T>
{
    public string Message { get; set; }
    public T Item { get; set; }
    public SuccessResult() : base(true) { }
    public SuccessResult(string message) : base(true)
    {
        Message = message;
    }
    public SuccessResult(T item, string message) : base(true)
    {
        Item = item;
        Message = message;
    }
}

