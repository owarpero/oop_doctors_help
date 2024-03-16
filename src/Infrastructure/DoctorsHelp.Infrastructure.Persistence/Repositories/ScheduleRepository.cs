using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Contexts;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public class ScheduleRepository : RepositoryBase<Schedule, ScheduleModel>, IScheduleRepository
{
    public ScheduleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ScheduleModel GetSchedule(int id)
    {
        return GetEntry(new Schedule { Id = id }).Entity;
    }

    public bool Delete(Schedule schedule)
    {
        Remove(schedule);
        return true;
    }

    protected override DbSet<ScheduleModel> DbSet => ((ApplicationDbContext)Context).Schedules;

    protected override ScheduleModel MapFrom(Schedule entity)
    {
        return new ScheduleModel
        {
            Id = entity.Id,
            EmployeeId = entity.Employee?.Id ?? 0,
            DateStart = entity.DateStart,
            DateEnd = entity.DateEnd,
            Status = entity.Status,
        };
    }

    protected override bool Equal(Schedule entity, ScheduleModel model)
    {
        return entity.Id == model.Id;
    }

    protected override void UpdateModel(ScheduleModel model, Schedule entity)
    {
        model.EmployeeId = entity.Employee?.Id ?? 0;
        model.DateStart = entity.DateStart;
        model.DateEnd = entity.DateEnd;
        model.Status = entity.Status;
    }
}