using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface ISpecializationService
{
    Specialization Create(string name, string description);

    Specialization GetSpecialization(int id);

    Specialization Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}