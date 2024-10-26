using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Trainees;

namespace UFit.Application.Trainees.Create;
internal sealed class CreateTraineeCommandHandler : ICommandHandler<CreateTraineeCommand, Guid>
{
    private readonly ITraineeRepository _traineeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTraineeCommandHandler(ITraineeRepository traineeRepository, IUnitOfWork unitOfWork)
    {
        _traineeRepository = traineeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTraineeCommand request, CancellationToken cancellationToken)
    {
        var trainee = Trainee.Create(
            new Name(request.Trainee.FirstName, request.Trainee.LastName),
            new Measurements(request.Trainee.Height, request.Trainee.Weight),
            new Gender(request.Trainee.Gender),
            request.Trainee.DateOfBirth,
            new Email(request.Trainee.Email),
            new Phone(request.Trainee.Phone),
            new FitnessGoal(request.Trainee.FitnessGoal),
            new TargetWeight(request.Trainee.TargetWeigth));

        _traineeRepository.Add(trainee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return trainee.Id;
    }
}
