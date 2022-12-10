using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class EmployeesService : IEmployeesService
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesService(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<IEnumerable<EmployeeResponse>> GetAllEmployees()
    {
        var employees = await _employeesRepository.GetAllEmployees();

        return employees.Select(employee => employee.ToEmployeeResponse()).ToList();
    }

    public async Task<EmployeeResponse?> GetEmployeeById(Guid? employeeId)
    {
        if (employeeId == null) throw new ArgumentNullException();

        var employee = await _employeesRepository.GetEmployeeById(employeeId);

        return employee?.ToEmployeeResponse();
    }

    public async Task<EmployeeResponse> AddEmployee(AddEmployeeRequest addEmployeeRequest)
    {
        if (addEmployeeRequest == null) throw new ArgumentNullException();

        //validate model personAddRequest
        var employee = addEmployeeRequest.ToEmployee();
        employee.EmployeeId = Guid.NewGuid();
        await _employeesRepository.AddEmployee(employee);
        return employee.ToEmployeeResponse();
    }

    public async Task<bool> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest)
    {
        if (updateEmployeeRequest == null) throw new ArgumentNullException();

        var matchingEmployee = await _employeesRepository.GetEmployeeById(updateEmployeeRequest.EmployeeId);

        if (matchingEmployee == null) throw new ArgumentException();

        matchingEmployee.EmployeeName = updateEmployeeRequest.EmployeeName;
        matchingEmployee.Email = updateEmployeeRequest.Email;
        matchingEmployee.Phone = updateEmployeeRequest.Phone;
        matchingEmployee.DateOfBirth = updateEmployeeRequest.DateOfBirth;
        matchingEmployee.DepartmentId = updateEmployeeRequest.DepartmentId;

        return await _employeesRepository.UpdateEmployee(matchingEmployee);
    }

    public async Task<bool> DeleteEmployee(Guid? employeeId)
    {
        if (employeeId == null) throw new ArgumentNullException();

        var employee = await _employeesRepository.GetEmployeeById(employeeId);

        if (employee == null) throw new ArgumentException();

        return await _employeesRepository.DeleteEmployee(employeeId);
    }
}