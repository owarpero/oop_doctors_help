namespace DoctorsHelp.Application.Contracts;

using DoctorsHelp.Application.Models;

public interface IEmployeeService
{
    Employee Create(User user, Specialization specialization, string graduate, string experience);

    Employee Get();

    Employee Get(int id);

    Employee Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}