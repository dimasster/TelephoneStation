using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Receipts.GetAll;

public class GetAllReceiptsHandler : IRequestHandler<GetAllReceiptsQuery, Result<IEnumerable<ReceiptDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllReceiptsHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ReceiptDTO>>> Handle(GetAllReceiptsQuery request, CancellationToken cancellationToken)
    {
        var receipts = await _repositoryWrapper
            .ReceiptRepo
            .GetAllAsync();

        if (receipts is null)
        {
            return Result.Fail(new Error($"Cannot find any receipts"));
        }

        var receiptDtos = _mapper.Map<IEnumerable<ReceiptDTO>>(receipts);
        return Result.Ok(receiptDtos);
    }
}