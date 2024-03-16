namespace DoctorsHelp.Presentation.Http.Requests;

public class AppointmentPost
{
    public Guid PatientId { get; set; }

    public int ScheduleId { get; set; }
}