using DoctorsHelp.Application.Contracts;
using DoctorsHelp.Application.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsHelp.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        return collection;
    }
}