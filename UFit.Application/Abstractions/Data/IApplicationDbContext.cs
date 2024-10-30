using Microsoft.EntityFrameworkCore;
using UFit.Domain.Trainees;
using UFit.Domain.Workouts;

namespace UFit.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Trainee> Trainees { get; set; }
    DbSet<Workout> Workouts { get; set; }
}
