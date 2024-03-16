using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Interfaces;

public interface IAppointmentRepository
{
    void Add(Appointment appointment);

    AppointmentModel GetAppointment(int id);

    void UpdateAppointment(Appointment appointment);

    bool Delete(Appointment appointment);
}