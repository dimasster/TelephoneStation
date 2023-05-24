using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Account.LogOut;

public record LogOutAccountQuery(int user_id, VerificationDTO verification) : IRequest<Result<string>>; 
