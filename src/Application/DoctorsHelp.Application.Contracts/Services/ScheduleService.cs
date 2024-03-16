using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Converters;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using DoctorsHelp.Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Application.Contracts.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleService(ScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public Schedule Create(Employee employee, DateTime dateStart, DateTime dateEnd)
    {
        var schedule = new Schedule
        {
            // Assuming Appointment has a constructor or properties for this
            Employee = employee,
            DateStart = dateStart,
            DateEnd = dateEnd,
        };
        _scheduleRepository.Add(schedule);
        return schedule;
    }

    public Schedule? GetSchedule(int scheduleId)
    {
        var scheduleModel = _scheduleRepository.GetSchedule(scheduleId);

        return ScheduleConverter.ScheduleModelToSchedule(scheduleModel);
    }

    public Schedule Update(int id, Dictionary<string, string> data)
    {
        ScheduleModel scheduleToUpdate = _scheduleRepository.GetSchedule(id);

        foreach (var entry in data)
        {
            switch (entry.Key)
            {
                case "EmployeeId":
                    int employeeId;
                    if (int.TryParse(entry.Value, out employeeId))
                        scheduleToUpdate.EmployeeId = employeeId;
                    break;
                case "DateStart":
                    scheduleToUpdate.DateStart = new DateTime(Convert.ToInt32(entry.Value));
                    break;
                case "DateEnd":
                    scheduleToUpdate.DateEnd = new DateTime(Convert.ToInt32(entry.Value));
                    break;
            }
        }

        return ScheduleConverter.ScheduleModelToSchedule(scheduleToUpdate);
    }

    public bool Delete(int id)
    {
        return _scheduleRepository.Delete(new Schedule { Id = id, });
    }
}