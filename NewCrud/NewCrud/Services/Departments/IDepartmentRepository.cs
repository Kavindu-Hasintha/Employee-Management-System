namespace NewCrud.Services.Departments
{
    public interface IDepartmentRepository
    {
        ICollection<Department> GetAllDepartments();
        Department GetDepartment(int id);
        bool DepartmentExists(string name);
        bool CreateDepartment(Department department);
        bool Save();
    }
}
