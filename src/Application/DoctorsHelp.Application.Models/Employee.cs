namespace DoctorsHelp.Application.Models;

public class Employee
{
    public int Id { get; set; }

    public User User { get; set; }

    public int Specialization { get; set; }

    public string Graduate { get; set; }

    public string Experience { get; set; }
}