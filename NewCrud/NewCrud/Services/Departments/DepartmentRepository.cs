namespace NewCrud.Services.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateDepartment(Department department)
        {
            _context.Add(department);
            return Save();
        }

        public bool DepartmentExists(string name)
        {
            return _context.Departments.Any(x => x.Name == name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
