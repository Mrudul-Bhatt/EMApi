using Entities;

namespace ServiceContracts.DTO;

public class EmployeeResponse
{
    public Guid EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Guid DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public double? Age { get; set; }
}

public static class EmployeeExtensions
{
    public static EmployeeResponse ToEmployeeResponse(this Employee employee)
    {
        return new EmployeeResponse
        {
            EmployeeId = employee.EmployeeId,
            EmployeeName = employee.EmployeeName,
            Email = employee.Email,
            Phone = employee.Phone,
            DateOfBirth = employee.DateOfBirth,
            DepartmentId = employee.DepartmentId,
            //AddEmployee does not return response with DepartmentName when adding Employee. Only GetAllEmployees and GetEmployeeById return DepartmentName. So we will get exception if we try to convert response from AddEmployee to EmployeeResponse object because we dont have DepartmentName, so always add ? check on nullable fields to avoid exceptions
            DepartmentName = employee.Department?.DepartmentName,
            Age = employee.DateOfBirth != null
                ? Math.Round((DateTime.Now - employee.DateOfBirth.Value).TotalDays / 365.25)
                : 0
        };
    }
}