using NewCrud.Models;

namespace NewCrud.Services.Employees
{
    public interface IEmployeeRepository
    {
        Task<Object> GetEmployees();
        Task<bool> EmployeeExists(string firstName);
        Task<bool> RegisterEmployee(Employee employee);
        Task<bool> Save();
    }
}
