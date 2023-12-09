namespace NewCrud.Services.Departments
{
    public interface IDepartmentRepository
    {
        bool DepartmentExists(string name);
        bool CreateDepartment(Department department);
        bool Save();
    }
}
