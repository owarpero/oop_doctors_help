using DoctorsHelp.Application.Contracts;
using DoctorsHelp.Application.Models;
using DoctorsHelp.Presentation.Http.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelp.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(Guid id)
    {
        var user = _userService.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost("register")]
    public ActionResult<User> Register([FromBody] UserPost data)
    {
        if (string.IsNullOrWhiteSpace(data.Name) ||
            string.IsNullOrWhiteSpace(data.Surname) ||
            string.IsNullOrWhiteSpace(data.Phone) ||
            string.IsNullOrWhiteSpace(data.Email) ||
            string.IsNullOrWhiteSpace(data.Password))
        {
            return BadRequest("All fields are required.");
        }

        try
        {
            var user = _userService.Register(data.Name, data.Surname, data.Phone, data.Email, data.Password, data.Birthdate);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while registering the user. " + ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<User> Update(Guid id, [FromBody] Dictionary<string, string> data)
    {
        try
        {
            var updatedUser = _userService.UpdateUser(id, data);
            return Ok(updatedUser);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var result = _userService.DeleteUser(id);
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