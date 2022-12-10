using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    private readonly AppDbContext _db;

    public EmployeesRepository(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await _db.Employees.Include(nameof(Department)).ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(Guid? employeeId)
    {
        return await _db.Employees.Include(nameof(Department))
            .FirstOrDefaultAsync(employee => employee.EmployeeId == employeeId);
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> UpdateEmployee(Employee employee)
    {
        var matchingEmployee = await GetEmployeeById(employee.EmployeeId);

        if (matchingEmployee == null) return false;

        matchingEmployee.EmployeeName = employee.EmployeeName;
        matchingEmployee.Email = employee.Email;
        matchingEmployee.Phone = employee.Phone;
        matchingEmployee.DateOfBirth = employee.DateOfBirth;
        matchingEmployee.DepartmentId = employee.DepartmentId;

        var rowsChanged = await _db.SaveChangesAsync();
        return rowsChanged > 0;
    }

    public async Task<bool> DeleteEmployee(Guid? employeeId)
    {
        _db.Employees.RemoveRange(_db.Employees.Where(employee => employee.EmployeeId == employeeId));
        var rowsDeleted = await _db.SaveChangesAsync();
        return rowsDeleted > 0;
    }
}