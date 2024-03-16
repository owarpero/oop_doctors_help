using DoctorsHelp.Application.Contracts;
using DoctorsHelp.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelp.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class SpecializationController : ControllerBase
{
    private readonly ISpecializationService _specializationService;

    public SpecializationController(ISpecializationService specializationService)
    {
        _specializationService = specializationService;
    }

    [HttpGet("{id}")]
    public ActionResult<Specialization> Get(int id)
    {
        var specialization = _specializationService.GetSpecialization(id);
        if (specialization == null)
        {
            return NotFound();
        }

        return Ok(specialization);
    }

    [HttpPost]
    public ActionResult<Specialization> Post([FromBody] Specialization specialization)
    {
        if (specialization.Name == null || specialization.Description == null)
        {
            return BadRequest("Name and Description are required.");
        }

        try
        {
            var createdSpecialization = _specializationService.Create(specialization.Name, specialization.Description);
            return CreatedAtAction(nameof(Get), new { id = createdSpecialization.Id }, createdSpecialization);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the specialization." + ex);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Specialization> Update(int id, [FromBody] Dictionary<string, string> data)
    {
        try
        {
            var updatedSpecialization = _specializationService.Update(id, data);
            return Ok(updatedSpecialization);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _specializationService.Delete(id);
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