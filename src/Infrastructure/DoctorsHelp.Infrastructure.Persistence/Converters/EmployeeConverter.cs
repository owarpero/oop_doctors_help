using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Converters;

public class EmployeeConverter
{
    public static Employee EmployeeModelToEmployee(EmployeeModel? employeeModel)
    {
        return new Employee
        {
            Id = employeeModel?.Id,
            User = UserConverter.UserModelToUser(employeeModel?.User),
            Specialization = SpecializationConverter.SpecializationModelToSpecialization(employeeModel?.Specialization),
            Graduate = employeeModel?.Graduate,
            Experience = employeeModel?.Experience,
        };
    }
}