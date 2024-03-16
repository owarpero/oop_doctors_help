using DoctorsHelp.Application.Contracts;
using DoctorsHelp.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelp.Presentation.Http.Controllers;
[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("{id}")]
    public ActionResult<Appointment> Get(int id)
    {
        var appointment = _appointmentService.GetAppointment(id);
        if (appointment == null)
        {
            return NotFound();
        }

        return Ok(appointment);
    }

    [HttpPost]
    public ActionResult<Appointment> Post([FromBody] Appointment appointment)
    {
        if (appointment.Patient == null || appointment.Schedule == null)
        {
            return BadRequest("Patient and Schedule are required.");
        }

        try
        {
            var createdAppointment = _appointmentService.Create(appointment.Patient, appointment.Schedule);
            return CreatedAtAction(nameof(Get), new { id = createdAppointment.Id }, createdAppointment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the appointment." + ex);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Appointment> Update(int id, [FromBody] Dictionary<string, string> data)
    {
        try
        {
            var updatedAppointment = _appointmentService.Update(id, data);
            return Ok(updatedAppointment);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _appointmentService.Delete(id);
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