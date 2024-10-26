using UFit.Domain.Abstractions;

namespace UFit.Domain.Trainees;

public sealed class Trainee : Entity
{
    private Trainee(
        Guid id,
        Name name,
        Measurements measurements,
        Gender gender,
        DateOnly dateOfBirth,
        Email email,
        Phone phone,
        FitnessGoal fitnessGoal,
        TargetWeight targetWeight,
        Points points) 
        : base(id)
    {
        Name = name;
        Measurements = measurements;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Email = email;
        Phone = phone;
        FitnessGoal = fitnessGoal;
        TargetWeight = targetWeight;
        Points = points;
    }

    public Name Name { get; private set; }
    public Measurements Measurements { get; private set; }
    public Gender Gender { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public FitnessGoal FitnessGoal { get; private set; }
    public TargetWeight TargetWeight { get; private set; }
    public Points Points { get; private set; }

    public static Trainee Create(
        Name name,
        Measurements measurements,
        Gender gender,
        DateOnly dateOfBirth,
        Email email,
        Phone phone,
        FitnessGoal fitnessGoal,
        TargetWeight targetWeight)
    {
        var trainee = new Trainee(Guid.NewGuid(), name, measurements, gender, dateOfBirth, email, phone, fitnessGoal, targetWeight, new Points(0));

        trainee.RaiseDomainEvent(new TraineeCreatedDomainEvent(trainee.Id));

        return trainee;
    }
}
