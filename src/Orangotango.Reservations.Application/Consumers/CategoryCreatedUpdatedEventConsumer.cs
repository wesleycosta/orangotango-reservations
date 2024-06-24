using MassTransit;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Events.Rooms.Category;

namespace Orangotango.Reservations.Application.Consumers;

public class CategoryCreatedUpdatedEventConsumer(ILoggerService _logger) : ConsumerBase<CategoryCreatedUpdatedEvent>
{
    public override async Task Consume(ConsumeContext<CategoryCreatedUpdatedEvent> context)
    {
        _logger.Information(nameof(CategoryCreatedUpdatedEvent), context.Message.AggregateId.ToString(), context.Message.TranceId);

        await Task.CompletedTask;
    }
}
