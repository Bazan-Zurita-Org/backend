using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Shared;
using UFit.Domain.Workouts;

namespace UFit.Infrastructure.Configurations;
internal class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("workouts");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name)
            .HasConversion(
            name => name.Value,
            value => new Domain.Shared.Name(value));

        builder.Property(w => w.Goal)
            .HasConversion(
            goal => goal.Value,
            value => new Goal(value));

        builder
            .HasMany(w => w.WorkoutExercises)
            .WithOne()
            .HasForeignKey(we => we.WorkoutId);
    }
}
