﻿using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Trainees;

public sealed class Trainee : Entity
{
    private Trainee() { }
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
        Points points,
        string identityId) 
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
        IdentityId = identityId;
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
    public string IdentityId { get; }

    public static Result<Trainee> Create(
        Name name,
        Measurements measurements,
        Gender gender,
        DateOnly dateOfBirth,
        Email email,
        Phone phone,
        FitnessGoal fitnessGoal,
        TargetWeight targetWeight,
        string identityId)
    {
        var trainee = new Trainee(
            Guid.NewGuid(),
            name,
            measurements,
            gender,
            dateOfBirth,
            email,
            phone,
            fitnessGoal,
            targetWeight,
            new Points(0),
            identityId);

        trainee.RaiseDomainEvent(new TraineeCreatedDomainEvent(trainee.Id));

        return trainee;
    }

    public void AddPoints(int newPoints)
    {
        Points += new Points(newPoints); 
    }
}
