using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Account.LogIn;

public record LogInAccountQuery(AccountDTO account) : IRequest<Result<(UserDTO user, VerificationDTO verification)>>;
