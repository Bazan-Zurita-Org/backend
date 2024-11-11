using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Diets;

namespace UFit.Infrastructure.Configurations;
internal class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("meals");

        builder.HasKey(m => m.Id);

        builder
            .HasMany(m => m.FoodItems)
            .WithOne()
            .HasForeignKey(fi => fi.MealId);
    }
}
