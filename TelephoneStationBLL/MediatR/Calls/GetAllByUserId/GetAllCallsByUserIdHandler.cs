using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Calls.GetAllByUserId;

public class GetAllCallsByUserIdHandler : IRequestHandler<GetAllCallsByUserIdQuery, Result<IEnumerable<CallDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllCallsByUserIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<CallDTO>>> Handle(GetAllCallsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var calls = await _repositoryWrapper
            .CallRepo
            .GetAllAsync(
                predicate: call=>call.CallerId == request.user_id,
                include: c => c
                .Include(cl => cl.Caller)
                .Include(cl => cl.Target));

        var callDtos = _mapper.Map<IEnumerable<CallDTO>>(calls);
        return Result.Ok(callDtos);
    }
}