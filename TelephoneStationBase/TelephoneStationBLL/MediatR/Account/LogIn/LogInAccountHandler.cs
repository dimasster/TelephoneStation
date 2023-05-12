using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Calls.GetAll;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Account.LogIn;

public class LogInAccountHandler : IRequestHandler<LogInAccountQuery, Result<UserDTO>> 
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public LogInAccountHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<UserDTO>> Handle(LogInAccountQuery request, CancellationToken cancellationToken)
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

        var userDto = _mapper.Map<UserDTO>(user);
        return Result.Ok(userDto);
    }
}
