namespace DoctorsHelp.Presentation.Http.Requests;

public class UserPost
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateOnly Birthdate { get; set; }
}