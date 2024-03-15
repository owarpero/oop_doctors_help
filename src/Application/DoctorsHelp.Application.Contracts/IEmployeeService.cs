using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface IEmployeeService
{
    Employee Create(User user, Specialization specialization, string graduate, string experience);

    Employee GetEmployee();

    Employee GetById(int id);

    Employee Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}