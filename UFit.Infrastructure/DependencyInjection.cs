using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Authentication;
using UFit.Application.Abstractions.Data;
using UFit.Domain.Trainees;
using UFit.Domain.Workouts;
using UFit.Infrastructure.Authentication;
using UFit.Infrastructure.Repositories;

namespace UFit.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") 
            ?? throw new ArgumentNullException("Connection String not provided");

        services.AddDbContext<ApplicationDbContext>(conf => 
            conf.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ITraineeRepository, TraineeRepository>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();

        services.AddSingleton<IAuthenticationService, AuthenticationService>();

        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile("firebase-ufit.json")
        });

        return services;
    }
}
