using Orangotango.Core.Abstractions;
using Orangotango.Core.Domain;

namespace Orangotango.Reservations.Domain.Rooms.Aggregates;

public sealed class Room : EntityBase, IAggregateRoot
{
    public string Name { get; private set; }
    public int Number { get; private set; }
    public Guid RoomCategoryId { get; private set; }
    public Category Category { get; private set; }
}
