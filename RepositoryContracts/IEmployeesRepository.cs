using Entities;

namespace RepositoryContracts;

public interface IEmployeesRepository
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee?> GetEmployeeById(Guid? employeeId);
    Task<Employee> AddEmployee(Employee employee);
    Task<bool> UpdateEmployee(Employee employee);
    Task<bool> DeleteEmployee(Guid? employeeId);
}