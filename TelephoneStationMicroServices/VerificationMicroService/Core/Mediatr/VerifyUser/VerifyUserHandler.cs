using FluentResults;
using MediatR;

namespace VerificationMicroService.Core.Mediatr.VerifyUser;

internal class VerifyUserHandler : IRequestHandler<VerifyUserQuery, Result<bool>>
{
    readonly VerificationService _verificationService;

    public VerifyUserHandler(VerificationService verificationService)
    {
        _verificationService = verificationService;
    }

    public async Task<Result<bool>> Handle(VerifyUserQuery request, CancellationToken cancellationToken)
    {
        return Result.Ok(_verificationService.VerifyUser(request.verification));
    }
}
