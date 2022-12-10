using Entities;

namespace ServiceContracts.DTO;

public class EmployeeResponse
{
    public Guid EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public string Email { get; set; }

    public int Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Guid DepartmentId { get; set; }

    public string DepartmentName { get; set; }

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
            DepartmentName = employee.Department.DepartmentName,
            Age = employee.DateOfBirth != null
                ? Math.Round((DateTime.Now - employee.DateOfBirth.Value).TotalDays / 365.25)
                : 0
        };
    }
}