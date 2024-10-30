using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Workouts;

namespace UFit.Infrastructure.Configurations;
internal class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("exercises");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasConversion(
            name => name.Value,
            value => new Domain.Shared.Name(value));

        builder.Property(e => e.Sets)
            .HasConversion(
            sets => sets.Value,
            value => new Set(value));

        builder.Property(e => e.Reps)
           .HasConversion(
           reps => reps.Value,
           value => new Rep(value));

        builder.Property(e => e.Equipment)
           .HasConversion(
           equipment => equipment.Value,
           value => new Equipment(value));

        builder.Property(e => e.MuscleGroup)
            .HasConversion(
            muscleGroup => muscleGroup.Value,
            value => new MuscleGroup(value));

        builder.Property(e => e.Instructions)
            .HasConversion(
            instructions => instructions.Value,
            value => new Instructions(value));
    }
}