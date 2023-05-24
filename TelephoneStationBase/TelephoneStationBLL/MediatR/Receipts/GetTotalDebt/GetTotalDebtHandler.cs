using FluentResults;
using MediatR;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Receipts.GetTotalDebt;

public class GetTotalDebtHandler : IRequestHandler<GetTotalDebtQuery, Result<double>>
{
    readonly IRepositoryWrapper _repository;

    public GetTotalDebtHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<double>> Handle(GetTotalDebtQuery request, CancellationToken cancellationToken)
    {
        //todo add verification
        var receipts = await _repository.ReceiptRepo.GetAllAsync(r => r.UserId == request.user_id);
        if (receipts == null) 
            return Result.Ok(0.0);

        return Result.Ok(0.0 - receipts.Where(r => r.IsBought == false).Sum(r => r.Price));
    }
}
