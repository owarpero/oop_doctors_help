using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Contexts;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public class AppointmentRepository : RepositoryBase<Appointment, AppointmentModel>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public AppointmentModel GetAppointment(int id)
    {
        return GetEntry(new Appointment { Id = id }).Entity;
    }

    public void UpdateAppointment(Appointment appointment)
    {
        Update(appointment);
    }

    public bool Delete(Appointment appointment)
    {
        Remove(appointment);
        return true;
    }

    protected override DbSet<AppointmentModel> DbSet => ((ApplicationDbContext)Context).Appointments;

    protected override AppointmentModel MapFrom(Appointment entity)
    {
        return new AppointmentModel
        {
            Id = entity.Id,
            PatientId = entity.Patient?.Id ?? Guid.Empty,
            ScheduleId = entity.Schedule?.Id ?? 0,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Status = entity.Status,
        };
    }

    protected override bool Equal(Appointment entity, AppointmentModel model)
    {
        return entity.Id == model.Id;
    }

    protected override void UpdateModel(AppointmentModel model, Appointment entity)
    {
        model.PatientId = entity.Patient?.Id ?? Guid.Empty;
        model.ScheduleId = entity.Schedule?.Id ?? 0;
        model.CreatedAt = entity.CreatedAt;
        model.UpdatedAt = entity.UpdatedAt;
        model.Status = entity.Status;
    }
}