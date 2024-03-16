using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Converters;

public class ScheduleConverter
{
    public static Schedule ScheduleModelToSchedule(ScheduleModel? scheduleModel)
    {
        return new Schedule
        {
            Id = scheduleModel?.Id,
            Employee = EmployeeConverter.EmployeeModelToEmployee(scheduleModel?.Employee),
            DateStart = scheduleModel?.DateStart,
            DateEnd = scheduleModel?.DateEnd,
            Status = scheduleModel?.Status,
        };
    }
}