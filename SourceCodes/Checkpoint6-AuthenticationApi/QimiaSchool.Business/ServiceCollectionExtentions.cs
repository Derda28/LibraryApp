using Microsoft.Extensions.DependencyInjection;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations;
using QimiaSchool.Business.Implementations.Handlers.Courses.Commands;
using QimiaSchool.Business.Implementations.MapperProfiles;
using MediatR;
using QimiaSchool.Business.Implementations.Handlers.Students.Commands;
using QimiaSchool.Business.Implementations.Handlers.Students.Queries;
using System.Reflection;

namespace QimiaSchool.Business;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
    {
        AddMediatRHandlers(services);
        AddManagers(services);
        AddAutoMapper(services);

        return services;
    }

    private static void AddMediatRHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

    private static void AddManagers(IServiceCollection services)
    {
        services.AddScoped<IStudentManager, StudentManager>();
        services.AddScoped<ICourseManager, CourseManager>();
        services.AddScoped<IEnrollmentManager, EnrollmentManager>();
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile));
    }
}
