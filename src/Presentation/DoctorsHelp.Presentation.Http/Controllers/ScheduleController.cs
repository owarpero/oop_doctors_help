using DoctorsHelp.Application.Contracts;
using DoctorsHelp.Application.Models;
using DoctorsHelp.Presentation.Http.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelp.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet("{id}")]
    public ActionResult<Schedule> Get(int id)
    {
        var schedule = _scheduleService.GetSchedule(id);
        if (schedule == null)
        {
            return NotFound();
        }

        return Ok(schedule);
    }

    [HttpPost]
    public ActionResult<Schedule> Post([FromBody] SchedulePost data)
    {
        if (data.DateStart == default || data.DateEnd == default)
        {
            return BadRequest("Employee, DateStart, and DateEnd are required.");
        }

        if (data.DateStart >= data.DateEnd)
        {
            return BadRequest("DateStart must be before DateEnd.");
        }

        try
        {
            var createdSchedule = _scheduleService.Create(data.EmployeeId, data.DateStart, data.DateEnd);
            return CreatedAtAction(nameof(Get), new { id = createdSchedule.Id }, createdSchedule);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the schedule. " + ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Schedule> Update(int id, [FromBody] Dictionary<string, string> data)
    {
        try
        {
            var updatedSchedule = _scheduleService.Update(id, data);
            return Ok(updatedSchedule);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _scheduleService.Delete(id);
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
