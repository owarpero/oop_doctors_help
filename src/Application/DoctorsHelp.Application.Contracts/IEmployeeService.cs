using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface IEmployeeService
{
    Employee Create(Guid userId, int specializationId, string graduate, string experience);

    Employee? GetEmployee(int employeeId);

    Employee Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}