using DoctorsHelp.Application.Contracts;
using DoctorsHelp.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelp.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        var employee = _employeeService.GetEmployee(id);
        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public ActionResult<Employee> Post([FromBody] Employee employee)
    {
        if (employee.User == null || employee.Specialization == null || string.IsNullOrWhiteSpace(employee.Graduate) || string.IsNullOrWhiteSpace(employee.Experience))
        {
            return BadRequest("User, Specialization, Graduate, and Experience are required.");
        }

        try
        {
            var createdEmployee = _employeeService.Create(employee.User, employee.Specialization, employee.Graduate, employee.Experience);
            return CreatedAtAction(nameof(Get), new { id = createdEmployee.Id }, createdEmployee);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the employee. " + ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Employee> Update(int id, [FromBody] Dictionary<string, string> data)
    {
        try
        {
            var updatedEmployee = _employeeService.Update(id, data);
            return Ok(updatedEmployee);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _employeeService.Delete(id);
        if (result)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
