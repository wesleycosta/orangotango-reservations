using PixelHotel.Core.Services;
using PixelHotel.Reservations.Business.Guests.Commands;

namespace PixelHotel.Reservations.Application.Guests.Abstractions;

public interface IGuestService
{
    Task<Result> Create(GuestCreateCommand command);
}
