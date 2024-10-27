using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Trainees;

namespace UFit.Infrastructure.Configurations;
public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
{
    public void Configure(EntityTypeBuilder<Trainee> builder)
    {
        builder.ToTable("trainees");

        builder.HasKey(t => t.Id);

        builder.OwnsOne(t => t.Name);

        builder.OwnsOne(t => t.Measurements);

        builder.Property(t => t.Gender)
            .HasConversion(
            gener => gener.Value,
            value => new Gender(value));

        builder.Property(t => t.Email)
            .HasConversion(
            email => email.Value,
            value => new Email(value));

        builder.Property(t => t.Phone)
            .HasConversion(
            phone => phone.Value,
            value => new Phone(value));

        builder.Property(t => t.FitnessGoal)
            .HasConversion(
            fitnessGoal => fitnessGoal.Value,
            value => new FitnessGoal(value));

        builder.Property(t => t.TargetWeight)
            .HasConversion(
            targetWeight => targetWeight.Value,
            value => new TargetWeight(value));

        builder.Property(t => t.Points)
            .HasConversion(
            points => points.Value,
            value => new Points(value));

        builder.HasIndex(t => t.Email)
            .IsUnique();
    }
}
