using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Interfaces;

public interface IEmployeeRepository
{
    void Add(Employee employee);

    EmployeeModel GetEmployee(int id);

    void UpdateEmployee(Employee employee);

    bool Delete(Employee employee);
}