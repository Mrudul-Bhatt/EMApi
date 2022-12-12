using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace EMApi.Controllers;

[Route("api/[controller]/[action]")]
public class EmployeesController : Controller
{
    private readonly IEmployeesService _employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        _employeesService = employeesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeesService.GetAllEmployees();
        return Ok(employees);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await _employeesService.GetEmployeeById(id);
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
    {
        var employee = await _employeesService.AddEmployee(addEmployeeRequest);
        return Ok(employee);
    }

    [HttpPut]
    // [Route("{id:guid}")]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest)
    {
        var result = await _employeesService.UpdateEmployee(updateEmployeeRequest);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var result = await _employeesService.DeleteEmployee(id);
        return Ok(result);
    }
}