using NewCrud.Models;

namespace NewCrud.Services.Employees
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<bool> EmployeeExists(string firstName);
        Task<bool> RegisterEmployee(Employee employee);
        Task<bool> Save();
    }
}
