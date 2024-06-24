using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
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
                        ExchangeName = "pixel-hotel-rooms-exchange",
                        QueueName = "pixel-hotel-rooms-events-to-reservations",
                        Consumers = [
                            typeof(CategoryUpsertEventConsumer),
                        ]
                    }
            ]
        };
}
