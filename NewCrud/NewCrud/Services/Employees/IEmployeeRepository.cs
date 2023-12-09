using NewCrud.Models;

namespace NewCrud.Services.Employees
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        bool EmployeeExists(string firstName);
        bool RegisterEmployee(Employee employee);
        bool Save();
    }
}
