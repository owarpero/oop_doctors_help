using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Converters;

public class AppointmentConverter
{
    public static Appointment AppointmentModelToAppointment(AppointmentModel? appointmentModel)
    {
        return new Appointment
        {
            Id = appointmentModel?.Id,
            Patient = UserConverter.UserModelToUser(appointmentModel?.Patient),
            Schedule = ScheduleConverter.ScheduleModelToSchedule(appointmentModel?.Schedule),
            CreatedAt = appointmentModel?.CreatedAt,
            UpdatedAt = appointmentModel?.UpdatedAt,
            Status = appointmentModel?.Status,
        };
    }
}