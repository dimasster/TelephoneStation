using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Services.Edit;

public record EditServiceCommand(ServiceDTO service, VerificationDTO verificarion) : IRequest<Result<ServiceDTO>>;
