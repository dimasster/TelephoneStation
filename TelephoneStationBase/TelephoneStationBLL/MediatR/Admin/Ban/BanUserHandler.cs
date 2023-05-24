using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.Services;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Enums;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Admin.Ban;

public class BanUserHandler : IRequestHandler<BanUserCommand, Result<string>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;
    readonly AuthorizationService _authorizationService;

    public BanUserHandler(IMapper mapper, IRepositoryWrapper repository, AuthorizationService authorization)
    {
        _mapper = mapper;
        _repository = repository;
        _authorizationService = authorization;
    }

    public async Task<Result<string>> Handle(BanUserCommand request, CancellationToken cancellationToken)
    {
        //todo replace with verify api
        _authorizationService.VerifyUser(request.verification);

        var user = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == request.user_id);
        if (user == null)
            return Result.Fail($"There is no user with id: {request.user_id}");

        //todo remove
        if (user.Role != UserRole.Admin)
            return Result.Fail("You don`t have permission to ban user");

        user.IsBanned = true;
        var updatedUser = _repository.UserRepo.Update(user);
        var updaterUserDto = _mapper.Map<User>(updatedUser);

        return Result.Ok($"You ban this user: \t{updaterUserDto}");
    }
}
