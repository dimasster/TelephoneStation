using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Ballance.Purchise;

public record PurchiseCommand(TransactionDTO purchise, VerificationDTO verification) : IRequest<Result<string>>;
