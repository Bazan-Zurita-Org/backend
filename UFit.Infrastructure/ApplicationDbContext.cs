using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Data;
using UFit.Domain.Challenges;
using UFit.Domain.Duels;
using UFit.Domain.Trainees;
using UFit.Domain.Workouts;

namespace UFit.Infrastructure;
public class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Duel> Duels { get; set; }
    public DbSet<WorkoutTrainee> WorkoutTrainees { get; set; }
    public DbSet<TraineeChallenge> TraineeChallenges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
