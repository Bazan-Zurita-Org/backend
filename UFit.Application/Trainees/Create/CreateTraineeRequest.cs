namespace UFit.Application.Trainees.Create;

public sealed record CreateTraineeRequest(
    string FirstName,
    string LastName,
    string Email,
    decimal Height,
    decimal Weight,
    string Gender,
    DateOnly DateOfBirth,
    string Phone,
    string FitnessGoal,
    decimal TargetWeigth);