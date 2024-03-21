using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Infra.Data;

namespace PixelHotel.Reservations.Infra.Data;

public class ReservationsContext(IPublisherEvent publisherEvent) : ContextBase(publisherEvent)
{
}
