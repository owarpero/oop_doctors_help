namespace DoctorsHelp.Application.Contracts;

using DoctorsHelp.Application.Models;

public interface IAppointmentService
{
    Appointment Create(User patient, Schedule schedule);

    Appointment Get(int patientId);

    Appointment Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}