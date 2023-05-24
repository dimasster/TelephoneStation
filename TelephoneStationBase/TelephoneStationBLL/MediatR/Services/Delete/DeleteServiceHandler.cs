using FluentResults;
using MediatR;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Services.Delete;

public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, Result<string>>
{
    readonly IRepositoryWrapper _repository;

    public DeleteServiceHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        //todo add admin verification
        var serviceToDelete = await _repository.ServiceRepo.GetSingleOrDefaultAsync(s => s.Id == request.id);
        if (serviceToDelete == null)
            return Result.Fail($"There is no such services with id {request.id}");

        _repository.ServiceRepo.Delete(serviceToDelete);

        return Result.Ok("You successfully delete the service");
    }
}
