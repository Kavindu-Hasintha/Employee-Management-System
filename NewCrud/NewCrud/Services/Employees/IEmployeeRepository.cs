using NewCrud.Models;

namespace NewCrud.Services.Employees
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
    }
}
