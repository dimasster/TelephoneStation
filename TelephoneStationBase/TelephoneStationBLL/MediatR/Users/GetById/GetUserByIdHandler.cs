using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Users.GetById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetUserByIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repositoryWrapper
            .UserRepo
            .GetSingleOrDefaultAsync(u => u.Id == request.id);

        if(user == null)
        {
            return Result.Fail(new Error($"Cannot find any user by {request.id} id"));
        }

        var userDtos = _mapper.Map<UserDTO>(user);
        return Result.Ok(userDtos);
    }
}