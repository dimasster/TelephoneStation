using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Enums;

namespace TelephoneStationBLL.MediatR.Account.SignUp;

public class SignUpAccountHandler : IRequestHandler<SignUpAccountCommand, Result<UserDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repository;

    public SignUpAccountHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<UserDTO>> Handle(SignUpAccountCommand request, CancellationToken cancellationToken)
    {
        if ( await _repository.AccountRepo
            .GetSingleOrDefaultAsync(
                predicate: acc => acc.Login.Equals(request.account.Login)
            ) != null)
        {
            return Result.Fail(new Error("this login is already in use"));
        }

        var account = _mapper.Map<TelephoneStationDAL.Entities.Account>(request.account);

        account.User = await _repository.UserRepo
            .CreateAsync(
                new User() { 
                    Name = "unknown",
                    LastName = "unknown",
                    PhoneNumber = 404,
                    Ballance = 0,
                    Role = UserRole.New
                });

        var createdAccount = await _repository.AccountRepo.CreateAsync(account);

        var createdUserDTO = _mapper.Map<UserDTO>(createdAccount.User);

        return Result.Ok(createdUserDTO);
    }
}
