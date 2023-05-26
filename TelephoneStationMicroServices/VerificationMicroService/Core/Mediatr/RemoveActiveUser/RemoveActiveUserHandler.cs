using FluentResults;
using MediatR;

namespace VerificationMicroService.Core.Mediatr.RemoveActiveUser;

internal class RemoveActiveUserHandler : IRequestHandler<RemoveActiveUserCommand, Result<bool>>
{
    readonly VerificationService _verificationService;

    public RemoveActiveUserHandler(VerificationService verificationService)
    {
        _verificationService = verificationService;
    }
    public async Task<Result<bool>> Handle(RemoveActiveUserCommand request, CancellationToken cancellationToken)
    {
        return Result.Ok(_verificationService.RemoveActiveUser(request.id, request.verification));
    }
}
