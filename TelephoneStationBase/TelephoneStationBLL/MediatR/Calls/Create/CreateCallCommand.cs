using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Calls.Create;

public record CreateCallCommand(CallCreateDTO call, VerificationDTO verification) : IRequest<Result<CallResponceDTO>>;
