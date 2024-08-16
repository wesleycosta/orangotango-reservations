﻿using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class ReservationCancelCommandValidator(IReservationRepository resevationRepository)
    : ReservationCommandWithIdValidatorBase<ReservationCancelCommand>(resevationRepository)
{
}
