using Microsoft.AspNetCore.Mvc;
using ResultTest.Models;

namespace ResultTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public FakeData FakeData { get; set; }
        public EmployeeController(FakeData fakeData)
        {
            FakeData = fakeData;
        }

        [HttpGet("GetEmployees")]
        public Result<List<Employee>> Get([FromQuery] Param param)
        {
            var emps = FakeData.GetEmployees();
            return Result<Employee>.SuccessPaginatedList(emps.AsQueryable(), param.PageSize, param.PageIndex, 100);

        }

        [HttpGet("GetEmployee/{id}")]
        public Result<Employee> Get(int id)
        {
            var emp = FakeData.GetEmployee(id);
            return Result<Employee>.Success(emp);
        }

        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            FakeData.DeleteEmployee(id);



            return Result<Employee>.Success(new Employee() { Id = 1, Name = "Mohamed" }, "تم الحذف");
        }
        [HttpPut("{id}")]
        public Result Put(int id, [FromBody] Employee employee)
        {
            // return Result.Failure(new ErrorModel("String.Format"));

            var emp = new EmployeeValidation();
            if (!emp.Validate(employee).IsValid)
            {
                return Result<Employee>.Failure(emp.Validate(employee).Errors.Select(x => new ValidationModel { PropertyName = x.PropertyName, Message = x.ErrorMessage }).ToList());
            }
            FakeData.EditEmployee(id, employee);
            return Result.Success();
        }
    }
}
