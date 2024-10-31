using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Exercises.Create;
public sealed record CreateExerciseCommand(CreateExerciseRequest Exercise) : ICommand;
