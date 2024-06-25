using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Consumers;

namespace Orangotango.Reservations.Application;

public class RegistrationConsumers : IBusConfiguration
{
    public BusConfiguration GetConfiguration(IConfiguration configuration)
        => new()
        {
            Receives =
            [
                new ReceiveConfiguration
                    {
                        ExchangeName = "orangotango-rooms-exchange",
                        QueueName = "orangotango-rooms-events-to-reservations",
                        Consumers = [
                            typeof(CategoryUpsertEventConsumer),
                            typeof(CategoryRemovedEventConsumer),
                            typeof(RoomUpsertEventConsumer),
                            typeof(RoomRemovedEventConsumer),
                        ]
                    }
            ]
        };

    public static void RegisterConsumers(IServiceCollection services)
    {
        services.AddScoped<IConsumer<CategoryUpsertedEvent>, CategoryUpsertEventConsumer>();
        services.AddScoped<IConsumer<CategoryRemovedEvent>, CategoryRemovedEventConsumer>();

        services.AddScoped<IConsumer<RoomUpsertedEvent>, RoomUpsertEventConsumer>();
        services.AddScoped<IConsumer<RoomRemovedEvent>, RoomRemovedEventConsumer>();
    }
}
