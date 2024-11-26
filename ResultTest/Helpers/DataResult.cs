public class DataResult<T> : Result<T>
{
    public T Value { get; set; }
    public DataResult(T value) : base(true, default)
    {
        Value = value;
    }
    public static Result<T> Success(T data) => new DataResult<T>(data);
}
