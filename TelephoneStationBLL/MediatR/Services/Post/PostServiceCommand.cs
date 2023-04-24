using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Services.Post;

public record PostServiceCommand(ServiceDTO service): IRequest<Result<ServiceDTO>>;
