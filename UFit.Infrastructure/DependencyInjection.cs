using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        AddPersistance(services, configuration);
        AddAuthentication(services, configuration);

        return services;
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAuthenticationService, AuthenticationService>();

        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile("firebase-ufit.json")
        });

        services.AddHttpClient<IJwtProvider, JwtProvider>((sp, httpClient) =>
        {
            var config = sp.GetRequiredService<IConfiguration>();

            httpClient.BaseAddress = new Uri(config["Authentication:TokenUri"]!);
        });

        services
            .AddAuthentication()
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
            {
                jwtOptions.Authority = configuration["Authentication:ValidIssuer"];
                jwtOptions.Audience = configuration["Authentication:Audience"];
                jwtOptions.TokenValidationParameters.ValidIssuer = configuration["Authentication:ValidIssuer"];
            });
    }

    private static void AddPersistance(IServiceCollection services, IConfiguration configuration)
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
    }
}
