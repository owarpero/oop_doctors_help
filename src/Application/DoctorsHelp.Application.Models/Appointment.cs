namespace DoctorsHelp.Application.Models;

public class Appointment
{
    public int Id { get; set; }

    public User Patient { get; set; }

    public Schedule Schedule { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int Status { get; set; }
}