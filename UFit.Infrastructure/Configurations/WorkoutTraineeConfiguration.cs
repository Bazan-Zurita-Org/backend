using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Trainees;
using UFit.Domain.Workouts;

namespace UFit.Infrastructure.Configurations;
internal class WorkoutTraineeConfiguration : IEntityTypeConfiguration<WorkoutTrainee>
{
    public void Configure(EntityTypeBuilder<WorkoutTrainee> builder)
    {
        builder.ToTable("workout_trainees");

        builder.HasKey(wt => new { wt.WorkoutId, wt.TraineeId });

        builder.HasOne<Workout>()
            .WithMany()
            .HasForeignKey(wt => wt.WorkoutId);

        builder.HasOne<Trainee>()
            .WithMany()
            .HasForeignKey(wt => wt.TraineeId);

    }
}
