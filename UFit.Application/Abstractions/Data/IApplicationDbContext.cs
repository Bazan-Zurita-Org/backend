using Microsoft.EntityFrameworkCore;
using UFit.Domain.Challenges;
using UFit.Domain.Duels;
using UFit.Domain.Trainees;
using UFit.Domain.Workouts;

namespace UFit.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Trainee> Trainees { get; set; }
    DbSet<Workout> Workouts { get; set; }
    DbSet<Exercise> Exercises { get; set; }
    DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    DbSet<Challenge> Challenges { get; set; }
    DbSet<Duel> Duels { get; set; }
    DbSet<WorkoutTrainee> WorkoutTrainees { get; set; }
    DbSet<TraineeChallenge> TraineeChallenges { get; set; }
}
