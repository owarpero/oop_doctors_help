namespace DoctorsHelp.Application.Contracts;

using DoctorsHelp.Application.Models;

public interface IReviewService
{
    Review Create(Appointment appointment, int grade, string comment);

    Review Get(int appointmentId);

    Review Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}