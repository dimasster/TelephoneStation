using FluentResults;
using MediatR;

namespace VerificationMicroService.Core.Mediatr.RemoveActiveUser;

internal record RemoveActiveUserCommand(int id, Verification verification) : IRequest<Result<bool>>;