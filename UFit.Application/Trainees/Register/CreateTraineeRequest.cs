namespace UFit.Application.Trainees.Register;

public sealed record CreateTraineeRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    decimal Height,
    decimal Weight,
    string Gender,
    DateOnly DateOfBirth,
    string Phone,
    string FitnessGoal,
    decimal TargetWeigth);