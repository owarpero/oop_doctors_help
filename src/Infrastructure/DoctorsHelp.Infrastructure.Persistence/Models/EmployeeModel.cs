namespace Infrastructure.Persistence.Models;

public class EmployeeModel
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public int SpecializationId { get; set; }

    public string? Graduate { get; set; }

    public string? Experience { get; set; }

    public UserModel? User { get; set; }

    public SpecializationModel? Specialization { get; set; }
}