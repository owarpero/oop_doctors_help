using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Interfaces;

public interface ISpecializationRepository
{
    void Add(Specialization specialization);

    SpecializationModel GetSpecialization(int id);

    void UpdateSpecialization(Specialization specialization);

    bool Delete(Specialization specialization);
}