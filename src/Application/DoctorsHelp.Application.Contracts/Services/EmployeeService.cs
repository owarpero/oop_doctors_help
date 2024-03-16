using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Converters;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using DoctorsHelp.Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Application.Contracts.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(EmployeeRepository appointmentRepository)
    {
        _employeeRepository = appointmentRepository;
    }

    public Employee Create(User user, Specialization specialization, string graduate, string experience)
    {
        var employee = new Employee
        {
            User = user,
            Specialization = specialization,
            Graduate = graduate,
            Experience = experience,
        };
        _employeeRepository.Add(employee);
        return employee;
    }

    public Employee? GetEmployee(int employeeId)
    {
        var employeeModel = _employeeRepository.GetEmployee(employeeId);

        return EmployeeConverter.EmployeeModelToEmployee(employeeModel);
    }

    public Employee Update(int id, Dictionary<string, string> data)
    {
        EmployeeModel employeeToUpdate = _employeeRepository.GetEmployee(id);

        foreach (var entry in data)
        {
            switch (entry.Key)
            {
                case "UserId":
                    Guid userId;
                    if (Guid.TryParse(entry.Value, out userId))
                        employeeToUpdate.UserId = userId;
                    break;
                case "SpecializationId":
                    int specializationId;
                    if (int.TryParse(entry.Value, out specializationId))
                        employeeToUpdate.SpecializationId = specializationId;
                    break;
                case "Graduate":
                    employeeToUpdate.Graduate = entry.Value;
                    break;
                case "Experience":
                    employeeToUpdate.Experience = entry.Value;
                    break;
            }
        }

        return EmployeeConverter.EmployeeModelToEmployee(employeeToUpdate);
    }

    public bool Delete(int id)
    {
        return _employeeRepository.Delete(new Employee { Id = id, });
    }
}