namespace DoctorsHelp.Presentation.Http.Requests;

public class EmployeePost
{
    public Guid UserId { get; set; }

    public int SpecializationId { get; set; }

    public string? Graduate { get; set; }

    public string? Experience { get; set; }
}