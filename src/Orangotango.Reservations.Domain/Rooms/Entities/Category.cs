using Orangotango.Core.Domain;

namespace Orangotango.Reservations.Domain.Rooms.Entities;

public sealed class Category : EntityBase
{
    public string Name { get; private set; }
    public IEnumerable<Room> Rooms { get; private set; }

    public Category(Guid id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public Category SetName(string name)
    {
        Name = name;
        return this;
    }
}
