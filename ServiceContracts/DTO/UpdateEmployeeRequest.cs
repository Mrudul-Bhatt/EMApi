using System;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace ServiceContracts.DTO
{
    public class UpdateEmployeeRequest
    {
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty!")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty!")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number cannot be empty!")]
        [Phone(ErrorMessage = "Phone number is invalid!")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Date of Birth cannot be empty!")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Department cannot be empty!")]
        public Guid DepartmentId { get; set; }

        public Employee ToEmployee()
        {
            return new Employee
            {
                EmployeeId = EmployeeId,
                EmployeeName = EmployeeName,
                Email = Email,
                Phone = Phone,
                DateOfBirth = DateOfBirth,
                DepartmentId = DepartmentId
            };
        }
    }
}