namespace DoctorsHelp.Application.Models;

public class Review
{
    public int Id { get; set; }

    public Appointment? Appointment { get; set; }

    public int Grade { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}