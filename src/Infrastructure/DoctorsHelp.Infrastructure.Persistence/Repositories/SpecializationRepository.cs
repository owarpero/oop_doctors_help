using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public class SpecializationRepository : RepositoryBase<Specialization, SpecializationModel>
{
    public SpecializationRepository(ApplicationDbContext context) : base(context)
    {
    }

    protected override DbSet<SpecializationModel> DbSet => ((ApplicationDbContext)Context).Specializations;

    protected override SpecializationModel MapFrom(Specialization entity)
    {
        return new SpecializationModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
        };
    }

    protected override bool Equal(Specialization entity, SpecializationModel model)
    {
        return entity.Id == model.Id;
    }

    protected override void UpdateModel(SpecializationModel model, Specialization entity)
    {
        model.Name = entity.Name;
        model.Description = entity.Description;
    }
}