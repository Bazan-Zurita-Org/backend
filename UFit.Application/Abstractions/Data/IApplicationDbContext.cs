using Microsoft.EntityFrameworkCore;
using UFit.Domain.Trainees;

namespace UFit.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Trainee> Trainees { get; set; }
}
