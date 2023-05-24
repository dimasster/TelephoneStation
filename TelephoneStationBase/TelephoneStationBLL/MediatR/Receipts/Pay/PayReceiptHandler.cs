using FluentResults;
using MediatR;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Receipts.Pay;

public class PayReceiptHandler : IRequestHandler<PayReceiptCommand, Result<string>>
{
    readonly IRepositoryWrapper _repository;

    public PayReceiptHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(PayReceiptCommand request, CancellationToken cancellationToken)
    {
        //todo add verification
        var receiptToPay = await _repository.ReceiptRepo.GetSingleOrDefaultAsync(r => r.Id == request.id);
        if (receiptToPay == null)
            return Result.Fail($"There is no receipt with id {request.id}");

        receiptToPay.IsBought = true;
        _repository.ReceiptRepo.Update(receiptToPay);

        return Result.Ok("You successfully pay for receipt");
    }
}
