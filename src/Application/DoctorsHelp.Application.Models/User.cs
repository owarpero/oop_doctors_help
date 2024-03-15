namespace DoctorsHelp.Application.Models;

public class User
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? HashedPassword { get; set; }

    public DateOnly Birthdate { get; set; }

    public string? Role { get; set; }
}