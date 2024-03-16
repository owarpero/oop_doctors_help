namespace Infrastructure.Persistence.Models;

public class ReviewModel
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public int Grade { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public AppointmentModel? Appointment { get; set; }
}