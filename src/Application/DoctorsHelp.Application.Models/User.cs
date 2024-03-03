namespace DoctorsHelp.Application.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Hashed_password { get; set; }

    public DateTime Birthdate { get; set; }

    public string Role { get; set; }
}