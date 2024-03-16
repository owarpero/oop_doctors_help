namespace DoctorsHelp.Presentation.Http.Requests;

public class SchedulePost
{
    public int EmployeeId { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }
}