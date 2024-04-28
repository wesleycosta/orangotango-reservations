using MassTransit;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Events;
using PixelHotel.Events.Rooms;
using PixelHotel.Events.Rooms.Category;

namespace PixelHotel.Reservations.Application.Consumers;

public class RoomRemovedEventConsumer : ConsumerBase<RoomRemovedEvent>
{
    private readonly ILoggerService _loggerService;

    public RoomRemovedEventConsumer(ILoggerService loggerService) =>
        _loggerService = loggerService;

    public override async Task Consume(ConsumeContext<RoomRemovedEvent> context)
    {
        _loggerService.Information("RoomRemovedEventConsumer", context.Message.AggregateId.ToString(), context.Message.TranceId);

        await Task.CompletedTask;
    }
}

public class CategoryCreatedUpdatedEventConsumer(ILoggerService _logger) : ConsumerBase<CategoryCreatedUpdatedEvent>
{
    public override async Task Consume(ConsumeContext<CategoryCreatedUpdatedEvent> context)
    {
        _logger.Information(nameof(CategoryCreatedUpdatedEvent), context.Message.AggregateId.ToString(), context.Message.TranceId);

        await Task.CompletedTask;
    }
}
