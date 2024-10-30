using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Workouts;

namespace UFit.Infrastructure.Configurations;
internal class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.ToTable("workout_exercises");

        builder.HasKey(we => new { we.WorkoutId, we.ExerciseId });

        builder.Property(we => we.Sets)
          .HasConversion(
          sets => sets.Value,
          value => new Set(value));

        builder.Property(we => we.Reps)
           .HasConversion(
           reps => reps.Value,
           value => new Rep(value));

        builder
            .HasOne<Workout>()
            .WithMany(w => w.WorkoutExercises)
            .HasForeignKey(we => we.WorkoutId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<Exercise>()
            .WithMany()
            .HasForeignKey(we => we.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
