using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Reservations.Application.Abstractions;

namespace Orangotango.Reservations.Application.Services;

internal sealed class ReservationPublisher(ILoggerService logger,
    IPublisherEvent publisherEvent) : PublisherEventBase(logger, publisherEvent), IReservationPublisher
{
}
