using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Calls.GetById;

public record GetCallByIdQuery(int id, VerificationDTO verification) : IRequest<Result<CallResponceDTO>>;