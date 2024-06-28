using Orangotango.Core.Services;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Rooms;

namespace Orangotango.Reservations.Application.Services;

internal sealed class RoomQueryService(IRoomMapper _mapper,
    IRoomRepository _repository,
    IReservationRepository _reservationRepository) : QueryServiceBase, IRoomQueryService
{
    public async Task<IEnumerable<RoomResult>> GetAll(Guid? reservationId)
    {
        var activeRooms = await GetActiveRooms();
        if (reservationId.HasValue)
        {
            return await GetRoomsIncludingReservedRoomAsync(reservationId.Value, activeRooms);
        }

        return activeRooms;
    }

    private async Task<IEnumerable<RoomResult>> GetRoomsIncludingReservedRoomAsync(Guid reservationId, IEnumerable<RoomResult> activeRooms)
    {
        var reservedRoomId = await _reservationRepository
               .GetFirstByExpression(reservation => reservation.Id == reservationId, reservation => reservation.RoomId);

        if (reservedRoomId == default || !activeRooms.Any(room => room.Id == reservedRoomId))
        {
            return activeRooms;
        }

        var removedRoom = await _repository.GetFirstByExpression(room => room.Id == reservedRoomId,
            room => _mapper.MapToResult(room));

        if (removedRoom != null)
        {
            var roomsWithRemovedRoom = activeRooms.ToList();
            roomsWithRemovedRoom.Add(removedRoom);

            return roomsWithRemovedRoom;
        }

        return activeRooms;
    }

    private async Task<IEnumerable<RoomResult>> GetActiveRooms()
       => await _repository.GetByExpression(filter => !filter.Removed,
           p => _mapper.MapToResult(p),
           order => order.Name);
}
