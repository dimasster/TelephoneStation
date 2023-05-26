using FluentResults;
using MediatR;

namespace VerificationMicroService.Core.Mediatr.AddActiveUser;

internal class AddActiveUserHandler : IRequestHandler<AddActiveUserCommand, Result<Verification>>
{
    readonly VerificationService _verificationService;

    public AddActiveUserHandler(VerificationService verificationService)
    {
        _verificationService = verificationService;
    }
    public async Task<Result<Verification>> Handle(AddActiveUserCommand request, CancellationToken cancellationToken)
    {
        var verification = _verificationService.AddActiveUser(request.id);
        if (verification == null)
            return Result.Fail("User is allready in system");

        return Result.Ok(verification);
    }
}
