public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public static bool HasValidationErrors { get; set; }

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public static Result Success() => new Result(true);
    public static Result Success(string SuccessMessage) => new SuccessResult(SuccessMessage);


    public static Result Failure() => new Result(false);
    public static Result Failure(ErrorModel error) => new ErrorResult(error);

    public static Result<T> Failure<T>(List<ValidationModel> validation)
    {
        HasValidationErrors = validation.Any();
        return new Result<T>(false, validation);
    }
    public static Result<T> Failure<T>(ErrorModel error) => new ErrorResult<T>(error);
}
public class Result<T> : Result
{
    //public T Data { get; set; }


    public Result(bool isSuccess, List<ValidationModel> validation = null) : base(isSuccess)
    {
        //  Data = data;
        HasValidationErrors = validation?.Count > 0;
    }
    public Result(bool isSuccess) : base(isSuccess)
    {
        // Data = data; 
    }
    public static Result<List<T>> SuccessList(List<T> items) => new DataListResult<T>(items);
    public static Result<T> Success(T data) => new DataResult<T>(data);
    public static Result<T> Success(T item, string SuccessMessage) => new SuccessResult<T>(item, SuccessMessage);
    // Pagination Result
    public static Result<List<T>> SuccessPaginatedList(IQueryable<T> items, int pageSize, int pageIndex, int totalCount) => new PaginationResult<T>(items, pageIndex, pageSize, totalCount);

    public static Result<T> Failure(List<ValidationModel> validations)
    {
        HasValidationErrors = validations?.Count > 0;
        return new ValidationErrorsResult<T>(validations);
    }
    public static Result<T> Failure(T data, ErrorModel error) => new ErrorResult<T>(error);
    public static implicit operator Result<T>(T data)
    {
        return Success(data);
    }





}

public class Param
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SortyBy { get; set; }
    public string? Direction { get; set; }
}

public class PaginationResult<T> : Result<List<T>>
{
    public int TotalCount { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; } = 50;

    public List<T> Data { get; set; }


    public PaginationResult(IQueryable<T> data, int pageIndex, int pageSize, int totalCount) : base(true)
    {

        TotalCount = totalCount;
        PageIndex = pageIndex;
        PageSize = pageSize;
        Data = data.Skip(pageIndex * pageSize).Take(pageSize).ToList();
    }

}
