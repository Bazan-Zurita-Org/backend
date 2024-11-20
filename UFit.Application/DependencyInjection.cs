using Microsoft.Extensions.DependencyInjection;
using UFit.Domain.Diets;
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
        services.AddTransient<DietService>();

        return services;
    }
}
