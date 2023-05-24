using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Calls.GetById;

public class GetCallByIdHandler : IRequestHandler<GetCallByIdQuery, Result<CallResponceDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetCallByIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<CallResponceDTO>> Handle(GetCallByIdQuery request, CancellationToken cancellationToken)
    {
        //add verification
        var call = await _repositoryWrapper
            .CallRepo
            .GetSingleOrDefaultAsync(
                predicate: c => c.Id == request.id,
                include: c => c
                    .Include(cl => cl.Caller)
                    .Include(cl => cl.Target));

        if (call is null)
        {
            return Result.Fail(new Error($"Cannot find any call by {request.id} id"));
        }

        var callDto = _mapper.Map<CallResponceDTO>(call);
        return Result.Ok(callDto);
    }
}