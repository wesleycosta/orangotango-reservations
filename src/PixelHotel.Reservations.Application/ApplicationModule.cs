using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Events;
using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Events.Rooms;
using PixelHotel.Reservations.Application.Consumers;

namespace PixelHotel.Reservations.Application;

public class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
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
                            typeof(RoomCreatedUpdatedConsumer),
                            typeof(RoomRemovedEventConsumer),
                       ]
                    }
                ]
            };
    }
}
