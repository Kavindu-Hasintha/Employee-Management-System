namespace NewCrud.Services.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public Department GetDepartment(int id)
        {
            return _context.Departments.Where(d => d.Id == id).FirstOrDefault();
        }

        public ICollection<Department> GetAllDepartments()
        {
            return _context.Departments.OrderBy(d => d.Id).ToList();
        }

        public bool DepartmentExists(string name)
        {
            return _context.Departments.Any(x => x.Name == name);
        }

        public bool CreateDepartment(Department department)
        {
            _context.Add(department);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
