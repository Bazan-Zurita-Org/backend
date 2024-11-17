using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Challenges;
using UFit.Domain.Shared;

namespace UFit.Infrastructure.Configurations;
internal class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.ToTable("challenges");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasConversion(
            name => name.Value,
            value => new Name(value));

        builder.Property(c => c.Description)
            .HasConversion(
            name => name.Value,
            value => new Description(value));

        builder.Property(c => c.Rewards)
            .HasConversion(
            rewards => rewards.Value,
            value => new Points(value));

        builder
            .HasMany(c => c.TraineeChallenges)
            .WithOne()
            .HasForeignKey(tc => tc.ChallengeId);

    }
}
