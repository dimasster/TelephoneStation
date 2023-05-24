using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Receipts.Create;

public class CreateReceiptHandler : IRequestHandler<CreateReceiptCommand, Result<ReceiptDTO>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;

    public CreateReceiptHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<Result<ReceiptDTO>> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
    {
        //todo add personal verification
        Receipt receipt;
        if (request.receipt.Type == "call receipt")
            receipt = _mapper.Map<CallReceipt>(request.receipt);
        else if (request.receipt.Type == "subscription receipt")
            receipt = _mapper.Map<SubscriptionReceipt>(request.receipt);
        else
            return Result.Fail("Receipt invalid type error");

        var createdReceipt = await _repository.ReceiptRepo.CreateAsync(receipt);

        var createdReceiptDto = _mapper.Map<ReceiptDTO>(createdReceipt);

        return Result.Ok(createdReceiptDto);
    }
}
