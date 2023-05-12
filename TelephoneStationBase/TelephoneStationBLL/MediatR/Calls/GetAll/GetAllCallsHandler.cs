using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Calls.GetAll;

public class GetAllCallsHandler : IRequestHandler<GetAllCallsQuery, Result<IEnumerable<CallDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllCallsHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<CallDTO>>> Handle(GetAllCallsQuery request, CancellationToken cancellationToken)
    {
        var calls = await _repositoryWrapper
            .CallRepo
            .GetAllAsync(
                include: c => c
                    .Include(cl => cl.Caller)
                    .Include(cl => cl.Target)
            );

        var callDtos = _mapper.Map<IEnumerable<CallDTO>>(calls);
        return Result.Ok(callDtos);
    }
}