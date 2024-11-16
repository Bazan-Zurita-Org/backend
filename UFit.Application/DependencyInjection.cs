using Microsoft.Extensions.DependencyInjection;
using UFit.Domain.Workouts;

namespace UFit.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddTransient<WorkoutService>();
        return services;
    }
}
