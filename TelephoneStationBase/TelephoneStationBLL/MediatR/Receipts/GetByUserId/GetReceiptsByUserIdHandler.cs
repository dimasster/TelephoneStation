using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Receipts.GetByUserId;
public class GetReceiptsByUserIdHandler : IRequestHandler<GetReceiptsByUserIdQuery, Result<IEnumerable<ReceiptDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetReceiptsByUserIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ReceiptDTO>>> Handle(GetReceiptsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var receipts = await _repositoryWrapper
            .ReceiptRepo
            .GetAllAsync(r => r.UserId == request.user_id);

        if (receipts is null)
        {
            return Result.Fail(new Error($"Cannot find any receipt by {request.user_id} user id"));
        }

        var receiptDtos = _mapper.Map<IEnumerable<ReceiptDTO>>(receipts);
        return Result.Ok(receiptDtos);
    }
}
