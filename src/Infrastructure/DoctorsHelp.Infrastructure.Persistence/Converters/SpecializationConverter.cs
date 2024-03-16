using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Converters;

public class SpecializationConverter
{
    public static Specialization SpecializationModelToSpecialization(SpecializationModel? specializationModel)
    {
        return new Specialization
        {
            Id = specializationModel?.Id,
            Name = specializationModel?.Name,
            Description = specializationModel?.Description,
        };
    }
}