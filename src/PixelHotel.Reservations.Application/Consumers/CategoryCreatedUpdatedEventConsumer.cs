using MassTransit;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Bus;
using PixelHotel.Events.Rooms.Category;

namespace PixelHotel.Reservations.Application.Consumers;

public class CategoryCreatedUpdatedEventConsumer(ILoggerService _logger) : ConsumerBase<CategoryCreatedUpdatedEvent>
{
    public override async Task Consume(ConsumeContext<CategoryCreatedUpdatedEvent> context)
    {
        _logger.Information(nameof(CategoryCreatedUpdatedEvent), context.Message.AggregateId.ToString(), context.Message.TranceId);

        await Task.CompletedTask;
    }
}
