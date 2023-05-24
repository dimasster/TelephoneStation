using FluentResults;
using MediatR;
using TelephoneStationDAL.Enums;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Calls.Finish;

public class FinishCallHandler : IRequestHandler<FinishCallCommand, Result<string>>
{
    readonly IRepositoryWrapper _repository;

    public FinishCallHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(FinishCallCommand request, CancellationToken cancellationToken)
    {
        //todo verify as caller, target or admin
        var callToUpdate = await _repository.CallRepo.GetSingleOrDefaultAsync(c => c.Id == request.id);
        if (callToUpdate == null)
            return Result.Fail($"There is no call with id {request.id}");

        var callStatus = callToUpdate.Status;

        switch(callStatus)
        {
            case CallStatus.Ititial:
                {
                    if (callToUpdate.CallerId == request.verification.Id)
                        callToUpdate.Status = CallStatus.Cancelled;
                    else
                        callToUpdate.Status = CallStatus.Rejected;
                    break;
                }
            case CallStatus.Started:
                {
                    callToUpdate.Status = CallStatus.Finished;
                    break;
                }
            default:
                return Result.Fail("This call is allready ended");
        }

        _repository.CallRepo.Update(callToUpdate);

        //todo create receipt to finished

        return Result.Ok("The call was ended");
    }
}
