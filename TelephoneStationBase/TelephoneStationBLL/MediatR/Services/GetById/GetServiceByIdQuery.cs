using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Services.GetById;

public record GetServiceByIdQuery(int id) : IRequest<Result<ServiceDTO>>;