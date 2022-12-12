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
    public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
    {
        if (id == null) return BadRequest("id is null");
        var employee = await _employeesService.GetEmployeeById(id);
        if (employee == null) return NotFound("Employee does not exist!");
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest addEmployeeRequest)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            return BadRequest(errors);
        }
        var employee = await _employeesService.AddEmployee(addEmployeeRequest);
        return Ok(employee);
    }

    [HttpPut]
    // [Route("{id:guid}")]
    public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest updateEmployeeRequest)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            return BadRequest(errors);
        }
        var result = await _employeesService.UpdateEmployee(updateEmployeeRequest);
        if (!result) return NotFound("Employee does not exist!");
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid? id)
    {
        if (id == null) return BadRequest("id should not be empty");
        var result = await _employeesService.DeleteEmployee(id);
        if (!result) return NotFound("Employee does not exist!");
        return Ok(result);
    }
}