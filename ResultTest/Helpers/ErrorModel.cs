public class ErrorModel
{
    public string Message { get; set; }
    public ErrorModel(string message)
    {
        Message = message;
    }
    public static implicit operator ErrorModel(string message)
    {
        return new ErrorModel(message);
    }


}
