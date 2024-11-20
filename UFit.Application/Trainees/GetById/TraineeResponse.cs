namespace UFit.Application.Trainees.GetById;

public sealed record TraineeResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    decimal Height,
    decimal Weight,
    string Gender,
    DateOnly DateOfBirth,
    string Phone,
    string FitnessGoal,
    decimal TargetWeigth,
    int Points,
    string IdentityId);
