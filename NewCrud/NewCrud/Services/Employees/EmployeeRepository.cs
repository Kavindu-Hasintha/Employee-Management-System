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
        public ICollection<Employee> GetEmployees()
        {
            return _context.Employees.OrderBy(e => e.eid).ToList();
        }
    }
}
