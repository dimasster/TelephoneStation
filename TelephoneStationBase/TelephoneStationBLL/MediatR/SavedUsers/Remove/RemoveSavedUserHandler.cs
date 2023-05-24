using FluentResults;
using MediatR;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.SavedUsers.Remove;

public class RemoveSavedUserHandler : IRequestHandler<RemoveSavedUserCommand, Result<string>>
{
    readonly IRepositoryWrapper _repository;

    public RemoveSavedUserHandler(IRepositoryWrapper repository)    
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(RemoveSavedUserCommand request, CancellationToken cancellationToken)
    {
        //todo add personal verification
        var savedUser = await _repository.SavedUserRepo.GetSingleOrDefaultAsync(
            s => s.UserId == request.savedUser.UsertId && s.TargetId == request.savedUser.TargetId);
        if (savedUser == null)
            return Result.Fail("Invalid request data");

        _repository.SavedUserRepo.Delete(savedUser);

        return Result.Ok("You successfully remove user from saved");
    }
}
