using MassTransit.SagaStateMachine;
using Orangotango.Core.Domain;

namespace Orangotango.Reservations.Domain.Rooms.Aggregates;

public sealed class Category : EntityBase
{
    public string Name { get; private set; }

    public Category(Guid id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public void SetName(string name)
        => Name = name;
}
