using PixelHotel.Core.Domain.Services;
using PixelHotel.Reservations.Business.Guests.Commands;

namespace PixelHotel.Reservations.Business.Guests.Abstractions;

public interface IGuestService
{
    Task<Result> Create(GuestCreateCommand command);
}
