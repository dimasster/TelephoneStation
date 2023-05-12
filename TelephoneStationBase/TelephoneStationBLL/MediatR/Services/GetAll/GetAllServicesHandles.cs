using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Services.GetAll;

public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, Result<IEnumerable<ServiceDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllServicesHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ServiceDTO>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _repositoryWrapper
            .ServiceRepo
            .GetAllAsync();

        var serviceDtos = _mapper.Map<IEnumerable<ServiceDTO>>(services);
        return Result.Ok(serviceDtos);
    }
}