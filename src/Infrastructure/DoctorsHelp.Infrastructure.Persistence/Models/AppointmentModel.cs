namespace Infrastructure.Persistence.Models;

public class AppointmentModel
{
    public int? Id { get; set; }

    public Guid PatientId { get; set; }

    public int ScheduleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? Status { get; set; }

    public UserModel? Patient { get; set; }

    public ScheduleModel? Schedule { get; set; }
}