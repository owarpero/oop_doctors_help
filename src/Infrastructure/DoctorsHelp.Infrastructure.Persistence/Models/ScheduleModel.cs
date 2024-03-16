namespace Infrastructure.Persistence.Models;

public class ScheduleModel
{
    public int? Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? Status { get; set; }

    public EmployeeModel? Employee { get; set; }
}