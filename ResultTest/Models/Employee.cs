using FluentValidation;

namespace ResultTest.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? TabCode { get; set; }

        public string? TegaraCode { get; set; }

    }

    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
