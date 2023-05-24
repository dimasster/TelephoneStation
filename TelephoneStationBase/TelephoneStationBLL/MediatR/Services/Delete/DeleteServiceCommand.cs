using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Services.Delete;

public record DeleteServiceCommand(int id, VerificationDTO verification) : IRequest<Result<string>>;