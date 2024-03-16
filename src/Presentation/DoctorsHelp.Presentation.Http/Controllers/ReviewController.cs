using DoctorsHelp.Application.Contracts;
using DoctorsHelp.Application.Models;
using DoctorsHelp.Presentation.Http.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelp.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("{id}")]
    public ActionResult<Review> Get(int id)
    {
        var review = _reviewService.GetReview(id);
        if (review == null)
        {
            return NotFound();
        }

        return Ok(review);
    }

    [HttpPost]
    public ActionResult<Review> Post([FromBody] ReviewPost data)
    {
        if (data.Grade < 1 || string.IsNullOrWhiteSpace(data.Comment))
        {
            return BadRequest("Appointment, Grade, and Comment are required.");
        }

        try
        {
            var createdReview = _reviewService.Create(data.AppointmentId, data.Grade, data.Comment);
            return CreatedAtAction(nameof(Get), new { id = createdReview.Id }, createdReview);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the review. " + ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Review> Update(int id, [FromBody] Dictionary<string, string> data)
    {
        try
        {
            var updatedReview = _reviewService.Update(id, data);
            return Ok(updatedReview);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _reviewService.Delete(id);
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
