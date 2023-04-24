using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.SavedUsers.GetByUserId;

public class GetSavedUsersByUserIdHandler : IRequestHandler<GetSavedUsersByUserIdQuery, Result<IEnumerable<UserDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetSavedUsersByUserIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<UserDTO>>> Handle(GetSavedUsersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var savedUsers = await _repositoryWrapper
            .SavedUserRepo
            .GetAllAsync(
                predicate: s => s.UserId == request.user_id,
                include: s => s.Include(sl => sl.Target));

        var targets = savedUsers.Select(s=>s.Target).ToList();

        var userDtos = _mapper.Map<IEnumerable<UserDTO>>(targets);
        return Result.Ok(userDtos);
    }
}