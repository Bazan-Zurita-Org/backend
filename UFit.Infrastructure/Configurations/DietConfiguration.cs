using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Diets;

namespace UFit.Infrastructure.Configurations;
internal class DietConfiguration : IEntityTypeConfiguration<Diet>
{
    public void Configure(EntityTypeBuilder<Diet> builder)
    {
        builder.ToTable("diets");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .HasConversion(
            name => name.Value,
            value => new Domain.Shared.Name(value));

        builder.Property(d => d.Goal)
            .HasConversion(
            goal => goal.Value,
            value => new Domain.Shared.Goal(value));

        builder.Property(d => d.Duration)
            .HasConversion(
            duration => duration.Value,
            value => new Duration(value));

        builder.OwnsOne(d => d.Calories);

        builder.OwnsOne(d => d.Proteins);

        builder.OwnsOne(d => d.Carbohydrates);

        builder.OwnsOne(d => d.Fats);

        builder.HasMany(d => d.Meals)
            .WithOne()
            .HasForeignKey(meals => meals.DietId);
    }
}
