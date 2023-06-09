﻿using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Calls.GetAllByUserId;

public record GetAllCallsByUserIdQuery(int user_id, VerificationDTO verification) : IRequest<Result<IEnumerable<CallResponceDTO>>>;