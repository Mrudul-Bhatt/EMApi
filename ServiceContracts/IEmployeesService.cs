using ServiceContracts.DTO;

namespace ServiceContracts;

public interface IEmployeesService
{
    Task<IEnumerable<EmployeeResponse>> GetAllEmployees();
    Task<EmployeeResponse?> GetEmployeeById(Guid? employeeId);
    Task<EmployeeResponse> AddEmployee(AddEmployeeRequest addEmployeeRequest);
    Task<bool> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest);
    Task<bool> DeleteEmployee(Guid? employeeId);
}