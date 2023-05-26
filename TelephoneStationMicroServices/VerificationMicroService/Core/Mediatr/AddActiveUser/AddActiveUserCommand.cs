using FluentResults;
using MediatR;

namespace VerificationMicroService.Core.Mediatr.AddActiveUser;

internal record AddActiveUserCommand(int id) : IRequest<Result<Verification>>;