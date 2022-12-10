using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace EMApi.Controllers;

[Route("api/[controller]")]
public class EmployeesController : Controller
{
    private readonly IEmployeesService _employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        _employeesService = employeesService;
    }

    [Route("[action]")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeesService.GetAllEmployees();
        return Ok(employees);
    }
}