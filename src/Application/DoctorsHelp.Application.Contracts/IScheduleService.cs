using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface IScheduleService
{
    Review Create(Employee employee, DateTime dateStart, DateTime dateEnd);

    Review GeSchedule(int employeeId);

    Review Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}