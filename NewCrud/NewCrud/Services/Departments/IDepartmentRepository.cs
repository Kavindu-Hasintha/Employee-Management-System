namespace NewCrud.Services.Departments
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartment(int id);
        bool DepartmentExists(string name);
        Task<bool> CreateDepartment(Department department);
        Task<bool> DeleteDepartment(int id);
        Task<bool> UpdateDepartment(int id, DepartmentDto departmentUpdate);
        Task<bool> Save();
    }
}
