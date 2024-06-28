using Orangotango.Reservations.Application.Results;

namespace Orangotango.Reservations.Application.Abstractions;

public interface IRoomQueryService
{
    Task<IEnumerable<RoomResult>> GetAll(Guid? reservationId);
}
