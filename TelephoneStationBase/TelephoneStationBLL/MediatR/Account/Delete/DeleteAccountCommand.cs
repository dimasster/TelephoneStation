using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Account.Delete;

public record DeleteAccountCommand(int user_id, VerificationDTO verification) : IRequest<Result<string>>;
