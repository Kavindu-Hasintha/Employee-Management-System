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

        public async Task<bool> EmployeeExists(string firstName)
        {
            return await _context.Employees.AnyAsync(emp => emp.FirstName == firstName);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.Include(e => e.Department).OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<bool> RegisterEmployee(Employee employee)
        {
            _context.Add(employee);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
