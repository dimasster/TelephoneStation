using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Users.Edit;

public class EditUserHandler : IRequestHandler<EditUserCommand, Result<UserDTO>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;

    public EditUserHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<UserDTO>> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        //todo add verification
        var userToEdit = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == request.user.Id);
        if (userToEdit == null)
            return Result.Fail($"There is no user with id {request.user.Id}");

        if (request.user.IsBanned != userToEdit.IsBanned)
            return Result.Fail("You cannot edit ban state of the user like this");

        if(request.user.Name != null)
            userToEdit.Name = request.user.Name;
        if(request.user.LastName != null)
            userToEdit.LastName = request.user.LastName;
        if(request.user.PhoneNumber != userToEdit.PhoneNumber)
            userToEdit.PhoneNumber = request.user.PhoneNumber;

        var editedUser = _repository.UserRepo.Update(userToEdit);
        var editedUserDto = _mapper.Map<UserDTO>(editedUser);

        return Result.Ok(editedUserDto);
    }
}
