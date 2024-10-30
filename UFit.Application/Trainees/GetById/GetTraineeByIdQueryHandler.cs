using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Trainees;

namespace UFit.Application.Trainees.GetById;
internal class GetTraineeByIdQueryHandler : IQueryHandler<GetTraineeByIdQuery, TraineeResponse>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetTraineeByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<TraineeResponse>> Handle(GetTraineeByIdQuery request, CancellationToken cancellationToken)
    {
        var trainee = await _applicationDbContext.
            Trainees.
            FirstOrDefaultAsync(t => t.Id == request.Id);

        if (trainee is null)
        {
            return Result.Failure<TraineeResponse>(TraineeErrors.NotFound);
        }

        return new TraineeResponse(
            trainee.Id,
            trainee.Name.First,
            trainee.Name.Last,
            trainee.Email.Value,
            trainee.Measurements.Height,
            trainee.Measurements.Weight,
            trainee.Gender.Value,
            trainee.DateOfBirth,
            trainee.Phone.Value,
            trainee.FitnessGoal.Value,
            trainee.TargetWeight.Value);
    }
}
