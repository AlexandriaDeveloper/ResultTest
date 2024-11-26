public class ValidationErrorsResult<T> : Result<T>
{
    public List<ValidationModel>? Validations { get; set; }

    public ValidationErrorsResult(List<ValidationModel> validations) : base(false, validations)
    {
        Validations = validations;
    }

}
