using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Contexts;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : RepositoryBase<Employee, EmployeeModel>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public EmployeeModel GetEmployee(int id)
    {
        return GetEntry(new Employee { Id = id }).Entity;
    }

    public void UpdateEmployee(Employee employee)
    {
        Update(employee);
    }

    public bool Delete(Employee employee)
    {
        Remove(employee);
        return true;
    }

    protected override DbSet<EmployeeModel> DbSet => ((ApplicationDbContext)Context).Employees;

    protected override EmployeeModel MapFrom(Employee entity)
    {
        return new EmployeeModel
        {
            Id = entity.Id,
            UserId = entity.User?.Id ?? Guid.Empty,
            SpecializationId = entity.Specialization?.Id,
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
        model.SpecializationId = entity.Specialization?.Id;
        model.Graduate = entity.Graduate;
        model.Experience = entity.Experience;
    }
}