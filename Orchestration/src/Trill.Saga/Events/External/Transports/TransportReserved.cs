using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace Trill.Saga.Events.External.Transports
{
    [Message("transports")]
    public class TransportReserved : IEvent
    {
        public Guid ReservationId { get; }
        public Guid TransportId { get; }

        public TransportReserved(Guid reservationId, Guid transportId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
        }
    }
}
