using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Challenges;
using UFit.Domain.Trainees;

namespace UFit.Infrastructure.Configurations;
internal class TraineeChallengeConfiguration : IEntityTypeConfiguration<TraineeChallenge>
{
    public void Configure(EntityTypeBuilder<TraineeChallenge> builder)
    {
        builder.ToTable("trainee_challenges");

        builder.HasKey(tc => tc.Id);

        builder
            .HasOne<Trainee>()
            .WithMany()
            .HasForeignKey(tc => tc.TraineeId);
    }
}
