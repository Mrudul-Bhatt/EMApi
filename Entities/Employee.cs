using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Employee
    {
        [Key] public Guid EmployeeId { get; set; }

        [Required] public string EmployeeName { get; set; }

        [EmailAddress] public string Email { get; set; }

        [Phone] public int Phone { get; set; }

        [Required] public DateTime? DateOfBirth { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}