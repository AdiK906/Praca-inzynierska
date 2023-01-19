using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace Trill.Saga.Events.External.Atractions
{
    [Message("atractions")]
    public class AtractionReserved : IEvent
    {
        public Guid ReservationId { get; set; }
        public Guid AtractionId { get; set; }

        public AtractionReserved(Guid reservationId, Guid atractionId)
        {
            ReservationId = reservationId;
            AtractionId = atractionId;
        }
    }
}
