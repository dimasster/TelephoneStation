using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Services.GetAll;

public record GetAllServicesQuery : IRequest<Result<IEnumerable<ServiceDTO>>>;