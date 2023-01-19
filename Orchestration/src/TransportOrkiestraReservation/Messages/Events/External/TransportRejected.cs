using Convey.CQRS.Events;
using System;

namespace TransportOrkiestraReservation.Messages.Events.External
{
    public class TransportRejected : IRejectedEvent
    {
        public Guid ReservationId { get; set; }//mozliwe do zmiany
        public string Reason { get; }
        public string Code { get; }

        public TransportRejected(Guid reservationId, string reason, string code)
        {
            ReservationId = reservationId;
            Reason = reason;
            Code = code;
        }
    }
}
