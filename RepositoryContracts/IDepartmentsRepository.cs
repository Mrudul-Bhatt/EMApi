using Entities;

namespace RepositoryContracts;

public interface IDepartmentsRepository
{
    Task<IEnumerable<Department>> GetAllDepartments();
    Task<Department?> GetDepartmentById(Guid? departmentId);
    Task<Department> AddDepartment(Department department);
    Task<bool> UpdateDepartment(Department department);
    Task<bool> DeleteDepartment(Guid? departmentId);
}