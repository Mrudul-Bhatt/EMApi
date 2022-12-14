using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace EMApi.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/[controller]/[action]")]
public class DepartmentsController : Controller
{
    private readonly IDepartmentsService _departmentsService;

    public DepartmentsController(IDepartmentsService departmentsService)
    {
        _departmentsService = departmentsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDepartments()
    {
        var departments = await _departmentsService.GetAllDepartments();
        return Ok(departments);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetDepartmentById([FromRoute] Guid? id)
    {
        if (id == null) return BadRequest("Id is null");

        var department = await _departmentsService.GetDepartmentById(id);

        if (department == null) return NotFound("Dept does not exist!");

        return Ok(department);
    }

    //If you dont specify from body here, then it will by default accept value in URL params 
    [HttpPost]
    public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentRequest addDepartmentRequest)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            return BadRequest(errors);
        }

        var department = await _departmentsService.AddDepartment(addDepartmentRequest);
        return Ok(department);
    }

    [HttpPut]
    // [Route("{id:guid}")]
    public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequest updateDepartmentRequest)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            return BadRequest(errors);
        }

        var result = await _departmentsService.UpdateDepartment(updateDepartmentRequest);

        if (!result) return NotFound("Department does not exist!");

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteDepartment(Guid? id)
    {
        if (id == null) return BadRequest("id should not be empty");

        var result = await _departmentsService.DeleteDepartment(id);

        if (!result) return NotFound("Department does not exist!");

        return Ok(result);
    }
}