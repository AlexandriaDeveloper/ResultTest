

using ResultTest.Models;


namespace ResultTest
{
    public class FakeData
    {
        public static List<Employee> _employees = Create();

        //Fake Data for 100 Employees
        public FakeData()
        {


        }

        private static List<Employee> Create()
        {
            var temp = new List<Employee>();

            for (int i = 1; i <= 100; i++)
            {
                temp.Add(new Employee
                {
                    Name = "Mohamed" + i.ToString(),
                    Id = i,
                    TabCode = "TabCode" + i,
                    TegaraCode = "TegaraCode" + i
                });

            }
            return temp;

        }
        public List<Employee> GetEmployees()
        {
            var emps = _employees;
            return (emps.ToList());
        }

        public Employee GetEmployee(int id)
        {
            return _employees.Find(x => x.Id == id);
        }

        public void DeleteEmployee(int id)
        {
            var emp = _employees.Find(x => x.Id == id);
            _employees.Remove(emp);
        }
        public void EditEmployee(int id, Employee employee)
        {
            var emp = _employees.Find(x => x.Id == id);
            emp.Name = employee.Name;
            emp.TegaraCode = employee.TegaraCode;
            emp.TabCode = employee.TabCode;

        }
    }
}
