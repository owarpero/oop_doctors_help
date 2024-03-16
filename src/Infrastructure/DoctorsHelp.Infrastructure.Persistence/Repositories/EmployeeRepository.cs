using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : RepositoryBase<Employee, EmployeeModel>
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }

    protected override DbSet<EmployeeModel> DbSet => ((ApplicationDbContext)Context).Employees;

    protected override EmployeeModel MapFrom(Employee entity)
    {
        return new EmployeeModel
        {
            Id = entity.Id,
            UserId = entity.User?.Id ?? Guid.Empty,
            SpecializationId = entity.Specialization,
            Graduate = entity.Graduate,
            Experience = entity.Experience,
        };
    }

    protected override bool Equal(Employee entity, EmployeeModel model)
    {
        return entity.Id == model.Id;
    }

    protected override void UpdateModel(EmployeeModel model, Employee entity)
    {
        model.UserId = entity.User?.Id ?? Guid.Empty;
        model.SpecializationId = entity.Specialization;
        model.Graduate = entity.Graduate;
        model.Experience = entity.Experience;
    }
}