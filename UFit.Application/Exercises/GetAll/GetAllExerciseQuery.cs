using UFit.Application.Abstractions.Messaging;
using UFit.Application.Workouts.GetById;

namespace UFit.Application.Exercises.GetAll;
public sealed record GetAllExerciseQuery() : IQuery<List<ExerciseResponse>>;
