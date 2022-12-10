using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories;

public class DepartmentsRepository : IDepartmentsRepository
{
    private readonly AppDbContext _db;

    public DepartmentsRepository(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        return await _db.Departments.ToListAsync();
    }

    public async Task<Department?> GetDepartmentById(Guid? departmentId)
    {
        return await _db.Departments.FirstOrDefaultAsync(department => department.DepartmentId == departmentId);
    }

    public async Task<Department> AddDepartment(Department department)
    {
        _db.Departments.Add(department);
        await _db.SaveChangesAsync();
        return department;
    }

    public async Task<bool> UpdateDepartment(Department department)
    {
        var matchingDepartment = await GetDepartmentById(department.DepartmentId);

        //this would have been already checked in Services (Business Logic Layer)
        if (matchingDepartment == null) return false;

        matchingDepartment.DepartmentName = department.DepartmentName;
        var rowsChanged = await _db.SaveChangesAsync();
        return rowsChanged > 0;
    }

    public async Task<bool> DeleteDepartment(Guid? departmentId)
    {
        _db.Departments.RemoveRange(_db.Departments.Where(department => department.DepartmentId == departmentId));
        var rowsDeleted = await _db.SaveChangesAsync();
        return rowsDeleted > 0;
    }
}