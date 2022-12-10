using System;
using Entities;

namespace ServiceContracts.DTO
{
    public class DepartmentResponse
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public static class DepartmentExtensions
    {
        //the type of param received in the method determines whose extension method this is. This is of Department Entity and we can only call this by object of Department Entity
        public static DepartmentResponse ToDepartmentResponse(this Department department)
        {
            return new DepartmentResponse
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
        }
    }
}