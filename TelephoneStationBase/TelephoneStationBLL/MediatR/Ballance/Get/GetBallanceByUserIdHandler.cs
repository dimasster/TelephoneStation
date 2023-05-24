using FluentResults;
using MediatR;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Ballance.Get;

public class GetBallanceByUserIdHandler : IRequestHandler<GetBallanceByUserIdQuery, Result<double>>
{
    readonly IRepositoryWrapper _repository;

    public GetBallanceByUserIdHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<double>> Handle(GetBallanceByUserIdQuery request, CancellationToken cancellationToken)
    {
        //todo add personal verification
        var user = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == request.user_id);
        if (user == null)
            return Result.Fail($"There is no user with id: {request.user_id}");

        return Result.Ok(user.Ballance);
    }
}
