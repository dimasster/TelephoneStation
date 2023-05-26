using FluentResults;
using MediatR;

namespace VerificationMicroService.Core.Mediatr.VerifyUser;

internal record VerifyUserQuery(Verification verification) : IRequest<Result<bool>>;