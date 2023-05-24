using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Subscriptions.Unsubscribe;

public record UnsubscribeFromServiceCommand(int user_id, VerificationDTO verification) : IRequest<Result<string>>;