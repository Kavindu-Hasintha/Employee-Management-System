namespace NewCrud.Services.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _context.Departments.Where(d => d.Id == id).Include(e => e.Employees).FirstOrDefaultAsync();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _context.Departments.Include(d => d.Employees).OrderBy(d => d.Id).ToListAsync();
        }

        public bool DepartmentExists(string name)
        {
            return _context.Departments.Any(x => x.Name == name);
        }

        public async Task<bool> CreateDepartment(Department department)
        {
            _context.Add(department);
            return await Save();
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return false;
            }
            
            _context.Departments.Remove(department);
            return await Save();
        }

        public async Task<bool> UpdateDepartment(int id, DepartmentDto departmentUpdate)
        {
            var department = await _context.Departments.FindAsync(id);
            
            if (department == null)
            {
                return false;
            }

            department.Name = departmentUpdate.Name;
            _context.Update(department);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

    }
}
