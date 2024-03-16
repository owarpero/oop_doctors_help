using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Contexts;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public class SpecializationRepository : RepositoryBase<Specialization, SpecializationModel>, ISpecializationRepository
{
    public SpecializationRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void UpdateSpecialization(Specialization specialization)
    {
        Update(specialization);
    }

    public SpecializationModel GetSpecialization(int id)
    {
        return GetEntry(new Specialization { Id = id }).Entity;
    }

    public bool Delete(Specialization specialization)
    {
        Remove(specialization);
        return true;
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