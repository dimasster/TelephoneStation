using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Account.Verify;

public record VerifyAccountQuery(VerificationDTO verification) : IRequest<Result<int>>;
