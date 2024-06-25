using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Consumers;

namespace Orangotango.Reservations.Application;

public class RegistrationConsumers : IBusConfiguration
{
    public BusConfiguration GetConfiguration()
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
                        ]
                    }
            ]
        };

    public static void RegisterConsumers(IServiceCollection services)
    {
        services.AddScoped<IConsumer<CategoryUpsertedEvent>, CategoryUpsertEventConsumer>();
        services.AddScoped<IConsumer<CategoryRemovedEvent>, CategoryRemovedEventConsumer>();
    }
}
