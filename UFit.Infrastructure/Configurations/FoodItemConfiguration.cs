using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Diets;

namespace UFit.Infrastructure.Configurations;
internal class FoodItemConfiguration : IEntityTypeConfiguration<FoodItem>
{
    public void Configure(EntityTypeBuilder<FoodItem> builder)
    {
        builder.ToTable("food_items");

        builder.HasKey(fi => fi.Id);

        builder.Property(fi => fi.Name)
           .HasConversion(
           name => name.Value,
           value => new Domain.Shared.Name(value));

        builder.Property(fi => fi.Quantity)
            .HasConversion(
            quantity => quantity.Value,
            value => new Quantity(value));

        builder.OwnsOne(fi => fi.Macronutrients);
    }
}
