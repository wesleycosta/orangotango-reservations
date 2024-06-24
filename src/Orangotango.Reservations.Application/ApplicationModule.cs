using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Events.Rooms;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Consumers;

namespace Orangotango.Reservations.Application;

public class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IConsumer<CategoryCreatedUpdatedEvent>, CategoryCreatedUpdatedEventConsumer>();

        services.AddScoped<IConsumer<RoomCreatedOrUpdatedEvent>, RoomCreatedUpdatedConsumer>();
        services.AddScoped<IConsumer<RoomRemovedEvent>, RoomRemovedEventConsumer>();

        return services;
    }

    internal class RegistrationConsumers : IBusConfiguration
    {
        public BusConfiguration GetConfiguration()
            => new()
            {
                Receives =
                [
                    new ReceiveConfiguration
                    {
                        ExchangeName = "pixel-hotel-rooms-exchange",
                        QueueName = "pixel-hotel-rooms-events-to-reservations",
                        Consumers = [
                            typeof(CategoryCreatedUpdatedEventConsumer),

                            typeof(RoomCreatedUpdatedConsumer),
                            typeof(RoomRemovedEventConsumer)
                        ]
                    }
                ]
            };
    }
}
