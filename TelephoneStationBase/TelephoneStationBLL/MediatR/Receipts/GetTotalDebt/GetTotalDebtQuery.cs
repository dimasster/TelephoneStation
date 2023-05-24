using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Receipts.GetTotalDebt;

public record GetTotalDebtQuery(int user_id, VerificationDTO verification) : IRequest<Result<double>>;
