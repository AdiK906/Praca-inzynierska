using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace AtractionsOrkiestraReservation.Messages.Events.External
{
    public class AtractionRejected : IRejectedEvent
    {
        public Guid ReservationId{ get; set; }
        public string Reason { get; }
        public string Code { get; }

        public AtractionRejected(Guid reservationId, string reason, string code)
        {
            ReservationId = reservationId;
            Reason = reason;
            Code = code;
        }
    }
}
