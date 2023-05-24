using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Calls.Finish;

public record FinishCallCommand(int id, VerificationDTO verification) : IRequest<Result<string>>;
