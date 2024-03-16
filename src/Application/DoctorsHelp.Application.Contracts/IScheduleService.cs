using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface IScheduleService
{
    Schedule Create(Employee employee, DateTime dateStart, DateTime dateEnd);

    Schedule? GetSchedule(int scheduleId);

    Schedule Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}