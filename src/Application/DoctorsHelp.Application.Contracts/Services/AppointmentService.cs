using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Converters;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using DoctorsHelp.Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Application.Contracts.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUserRepository _patientRepository;
    private readonly IScheduleRepository _scheduleRepository;

    public AppointmentService(AppointmentRepository appointmentRepository, UserRepository userRepository, ScheduleRepository scheduleRepository)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = userRepository;
        _scheduleRepository = scheduleRepository;
    }

    public Appointment Create(Guid patientId, int scheduleId)
    {
        User patient = UserConverter.UserModelToUser(_patientRepository.GetUser(patientId));
        Schedule schedule = ScheduleConverter.ScheduleModelToSchedule(_scheduleRepository.GetSchedule(scheduleId));

        var appointment = new Appointment
        {
            // Assuming Appointment has a constructor or properties for this
            Patient = patient,
            Schedule = schedule,
        };
        _appointmentRepository.Add(appointment);
        return appointment;
    }

    public Appointment? GetAppointment(int patientId)
    {
        var appointmentModel = _appointmentRepository.GetAppointment(patientId);

        return AppointmentConverter.AppointmentModelToAppointment(appointmentModel);
    }

    public Appointment Update(int id, Dictionary<string, string> data)
    {
        AppointmentModel appointmentToUpdate = _appointmentRepository.GetAppointment(id);

        foreach (var entry in data)
        {
            switch (entry.Key)
            {
                case "PatientId":
                    Guid patientId;
                    if (Guid.TryParse(entry.Value, out patientId))
                        appointmentToUpdate.PatientId = patientId;
                    break;
                case "ScheduleId":
                    int scheduleId;
                    if (int.TryParse(entry.Value, out scheduleId))
                        appointmentToUpdate.ScheduleId = scheduleId;
                    break;
                case "Status":
                    int status;
                    if (int.TryParse(entry.Value, out status))
                        appointmentToUpdate.Status = status;
                    break;
            }
        }

        return AppointmentConverter.AppointmentModelToAppointment(appointmentToUpdate);
    }

    public bool Delete(int id)
    {
        return _appointmentRepository.Delete(new Appointment { Id = id, });
    }
}
