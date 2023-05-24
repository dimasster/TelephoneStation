using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Services.Edit;

public class EditServiceHandler : IRequestHandler<EditServiceCommand, Result<ServiceDTO>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;

    public EditServiceHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<Result<ServiceDTO>> Handle(EditServiceCommand request, CancellationToken cancellationToken)
    {
        //todo add admin verification
        var serviceToEdit = _mapper.Map<Service>(request.service);
        var editedService = _repository.ServiceRepo.Update(serviceToEdit);
        if (editedService == null)
            return Result.Fail("Cannot update this service");

        var editedServiceDto = _mapper.Map<ServiceDTO>(editedService);
        return Result.Ok(editedServiceDto);
    }
}
