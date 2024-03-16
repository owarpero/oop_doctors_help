using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Converters;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using DoctorsHelp.Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Application.Contracts.Services;

public class SpecializationService : ISpecializationService
{
    private readonly ISpecializationRepository _specializationRepository;

    public SpecializationService(SpecializationRepository specializationRepository)
    {
        _specializationRepository = specializationRepository;
    }

    public Specialization Create(string name, string description)
    {
        var specialization = new Specialization
        {
            Name = name,
            Description = description,
        };
        _specializationRepository.Add(specialization);
        return specialization;
    }

    public Specialization? GetSpecialization(int id)
    {
        var specializationModel = _specializationRepository.GetSpecialization(id);

        return SpecializationConverter.SpecializationModelToSpecialization(specializationModel);
    }

    public Specialization Update(int id, Dictionary<string, string> data)
    {
        SpecializationModel specializationToUpdate = _specializationRepository.GetSpecialization(id);

        foreach (var entry in data)
        {
            switch (entry.Key)
            {
                case "Name":
                    specializationToUpdate.Name = entry.Value;
                    break;
                case "Description":
                    specializationToUpdate.Description = entry.Value;
                    break;
            }
        }

        return SpecializationConverter.SpecializationModelToSpecialization(specializationToUpdate);
    }

    public bool Delete(int id)
    {
        return _specializationRepository.Delete(new Specialization { Id = id });
    }
}