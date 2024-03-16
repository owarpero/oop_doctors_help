using DoctorsHelp.Application.Contracts;
using DoctorsHelp.Application.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsHelp.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAppointmentService, AppointmentService>();
        collection.AddScoped<IEmployeeService, EmployeeService>();
        collection.AddScoped<IReviewService, ReviewService>();
        collection.AddScoped<IScheduleService, ScheduleService>();
        collection.AddScoped<ISpecializationService, SpecializationService>();
        collection.AddScoped<IUserService, UserService>();
        return collection;
    }
}