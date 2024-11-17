using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Challenges;
using UFit.Domain.Duels;
using UFit.Domain.Trainees;

namespace UFit.Infrastructure.Configurations;
internal class DuelConfiguration : IEntityTypeConfiguration<Duel>
{
    public void Configure(EntityTypeBuilder<Duel> builder)
    {
        builder.ToTable("duels");

        builder.HasKey(d => d.Id);

        builder.HasOne<Trainee>()
            .WithMany()
            .HasForeignKey(d => d.ChallengerId);


        builder.HasOne<Trainee>()
            .WithMany()
            .HasForeignKey(d => d.OpponentId);

        builder.HasOne<Challenge>()
            .WithMany()
            .HasForeignKey(d => d.ChallengeId);
    }
}
