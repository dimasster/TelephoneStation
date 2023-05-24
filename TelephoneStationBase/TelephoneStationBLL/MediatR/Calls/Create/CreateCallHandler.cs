using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Calls.Create;

public class CreateCallHandler : IRequestHandler<CreateCallCommand, Result<CallResponceDTO>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;

    public CreateCallHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<CallResponceDTO>> Handle(CreateCallCommand request, CancellationToken cancellationToken)
    {
        //todo add personal verification
        //todo add validation
        var call = _mapper.Map<Call>(request.call);

        var createdCall = await _repository.CallRepo.CreateAsync(call);
        createdCall.Caller = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == createdCall.CallerId);
        createdCall.Target = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == createdCall.TargetId);

        var createdCallDto = _mapper.Map<CallResponceDTO>(createdCall);

        return Result.Ok(createdCallDto);
    }
}
