public class DataListResult<T> : Result<List<T>>
{
    public List<T> Items { get; set; }
    public int Count => Items.Count;
    public DataListResult(List<T> items) : base(true, default)
    {
        Items = items;

    }
    public static Result<List<T>> SuccessList(List<T> items) => new DataListResult<T>(items);

}