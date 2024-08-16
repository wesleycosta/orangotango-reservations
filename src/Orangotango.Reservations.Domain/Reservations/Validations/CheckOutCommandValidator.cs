﻿using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class CheckOutCommandValidator(IReservationRepository resevationRepository)
    : ReservationCommandWithIdValidatorBase<CheckOutCommand>(resevationRepository)
{
}