using NewCrud.Data;
using NewCrud.Models;

namespace NewCrud.Services.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context) 
        {
            _context = context;
        }

        public bool EmployeeExists(string firstName)
        {
            return _context.Employees.Any(emp => emp.FirstName == firstName);
        }

        public ICollection<Employee> GetEmployees()
        {
            return _context.Employees.Include(e => e.Department).OrderBy(e => e.Id).ToList();
        }

        public bool RegisterEmployee(Employee employee)
        {
            _context.Add(employee);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
