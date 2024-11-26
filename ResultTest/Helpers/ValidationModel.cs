public class ValidationModel
{
    // public List<ValidationProperty> Properties { get; set; }

    public string Message { get; set; }
    public string PropertyName { get; set; }

    public ValidationModel() { }
    public ValidationModel(string message, string propertyName)
    {
        Message = message;
        PropertyName = propertyName;
    }



    public static implicit operator ValidationModel(ValidationProperty? properties)
    {
        return new ValidationModel() { Message = properties.Message, PropertyName = properties.PropertyName };
    }



}
