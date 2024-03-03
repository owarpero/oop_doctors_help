namespace DoctorsHelp.Application.Contracts;

using DoctorsHelp.Application.Models;

public interface ISpecializationService
{
    Specialization Create(string name, string description);

    Specialization Get(int id);

    Specialization Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}