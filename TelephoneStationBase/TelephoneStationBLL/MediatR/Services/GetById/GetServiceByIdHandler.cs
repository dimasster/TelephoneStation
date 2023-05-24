using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Services.GetById;

public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, Result<ServiceDTO>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;

    public GetServiceByIdHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<ServiceDTO>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _repository.ServiceRepo.GetSingleOrDefaultAsync(s => s.Id == request.id);
        if (service == null)
            return Result.Fail($"There is no service with id {request.id}");

        var serviceDto = _mapper.Map<ServiceDTO>(service);

        return Result.Ok(serviceDto);
    }
}
