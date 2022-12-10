using System.ComponentModel.DataAnnotations;
using Entities;

namespace ServiceContracts.DTO;

public class AddDepartmentRequest
{
    [Required(ErrorMessage = "Department cannot be empty!")]
    public string DepartmentName { get; set; }

    public Department ToDepartment()
    {
        return new Department
        {
            DepartmentName = DepartmentName
        };
    }
}