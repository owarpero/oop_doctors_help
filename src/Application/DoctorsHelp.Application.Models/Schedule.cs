namespace DoctorsHelp.Application.Models;

public class Schedule
{
    public Guid Id { get; set; }

    public Employee Employee { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int Status { get; set; }
}