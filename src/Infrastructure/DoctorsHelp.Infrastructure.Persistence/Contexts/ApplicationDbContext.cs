using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    required public DbSet<UserModel> Users { get; set; }

    required public DbSet<AppointmentModel> Appointments { get; set; }

    required public DbSet<EmployeeModel> Employees { get; set; }

    required public DbSet<ReviewModel> Reviews { get; set; }

    required public DbSet<ScheduleModel> Schedules { get; set; }

    required public DbSet<SpecializationModel> Specializations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}