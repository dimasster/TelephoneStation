using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Calls.GetAll;

public record GetAllCallsQuery(VerificationDTO verification) : IRequest<Result<IEnumerable<CallResponceDTO>>>;