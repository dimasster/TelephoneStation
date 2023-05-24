using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.SavedUsers.Add;

public class AddSavedUserHandler : IRequestHandler<AddSavedUserCommand, Result<UserDTO>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;
    
    public AddSavedUserHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<UserDTO>> Handle(AddSavedUserCommand request, CancellationToken cancellationToken)
    {
        //todo add personat verification 
        //todo add validation
        var savedUser = _mapper.Map<SavedUser>(request.savedUser);
        var createdSavedUser = await _repository.SavedUserRepo.CreateAsync(savedUser);

        if (createdSavedUser != null)
            Result.Fail("Unable to add the user to saved");

        var newSavedUser = await _repository.SavedUserRepo.GetSingleOrDefaultAsync(
            predicate: s => s.UserId == request.savedUser.UsertId && s.TargetId == request.savedUser.TargetId,
            include: s => s.Include(sl => sl.Target));

        if (newSavedUser == null)
            return Result.Fail("error");

        var user = newSavedUser.Target;
        var userDto = _mapper.Map<UserDTO>(user);

        return Result.Ok(userDto);
    }
}
