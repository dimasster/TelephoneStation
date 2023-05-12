using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Account.SignUp;

public record SignUpAccountCommand(AccountDTO account) : IRequest<Result<UserDTO>>;
