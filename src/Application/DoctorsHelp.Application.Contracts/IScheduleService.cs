namespace DoctorsHelp.Application.Contracts;

using DoctorsHelp.Application.Models;

public interface IScheduleService
{
    Review Create(Employee employee, DateTime dateStart, DateTime dateEnd);

    Review Get(int employeeId);

    Review Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}