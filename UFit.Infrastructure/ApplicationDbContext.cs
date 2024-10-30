using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Data;
using UFit.Domain.Trainees;

namespace UFit.Infrastructure;
public class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Trainee> Trainees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
