namespace DoctorsHelp.Presentation.Http.Requests;

public class ReviewPost
{
    public int AppointmentId { get; set; }

    public int Grade { get; set; }

    public string? Comment { get; set; }
}