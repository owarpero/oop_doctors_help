using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface IAppointmentService
{
    Appointment Create(Guid patientId, int scheduleId);

    Appointment? GetAppointment(int patientId);

    Appointment Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}
