using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UFit.Domain.Diets;
using UFit.Domain.Trainees;

namespace UFit.Infrastructure.Configurations;
internal class DietTraineeConfiguration : IEntityTypeConfiguration<DietTrainee>
{
    public void Configure(EntityTypeBuilder<DietTrainee> builder)
    {
        builder.ToTable("diet_trainees");

        builder.HasKey(dt => new { dt.DietId, dt.TraineeId });

        builder.HasOne<Diet>()
            .WithMany()
            .HasForeignKey(dt => dt.DietId);

        builder.HasOne<Trainee>()
            .WithMany()
            .HasForeignKey(dt => dt.TraineeId);
    }
}
