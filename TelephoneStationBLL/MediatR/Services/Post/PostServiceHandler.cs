using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Services.Post;

public class PostServiceHandler : IRequestHandler<PostServiceCommand, Result<ServiceDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public PostServiceHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<ServiceDTO>> Handle(PostServiceCommand request, CancellationToken cancellationToken)
    {
        var service = _mapper.Map<Service>(request.service);

        await _repositoryWrapper.ServiceRepo.CreateAsync(service);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;

        var createdService = _mapper.Map<ServiceDTO>(service);

        return resultIsSuccess ? Result.Ok(createdService) : Result.Fail(new Error("Failed to create a service"));
    }
}
