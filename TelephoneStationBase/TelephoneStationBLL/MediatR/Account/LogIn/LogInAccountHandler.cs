using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.Services;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Account.LogIn;

public class LogInAccountHandler : IRequestHandler<LogInAccountQuery, Result<(UserDTO user, VerificationDTO verification)>> 
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly AuthorizationService _authorizationService;

    public LogInAccountHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, AuthorizationService authorizationService)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
        _authorizationService = authorizationService;
    }

    public async Task<Result<(UserDTO user, VerificationDTO verification)>> Handle(LogInAccountQuery request, CancellationToken cancellationToken)
    {
        var account = await _repositoryWrapper
            .AccountRepo
            .GetSingleOrDefaultAsync(
                predicate: acc => acc.Login.Equals(request.account.Login)
                    && acc.Password.Equals(request.account.Password),
                include: acc => acc.Include(al => al.User)
            );

        if (account is null)
        {
            return Result.Fail(new Error($"Cannot log in"));
        }

        var user = account.User;   
        if (user is null)
            return Result.Fail(new Error($"Account is not linked to a user"));

        var verificationDto = _authorizationService.AddActiveUser(user.Id);
        if (verificationDto is null)
            return Result.Fail(new Error($"This user is already is system"));

        var userDto = _mapper.Map<UserDTO>(user);
        return Result.Ok((userDto, verificationDto));
    }
}
