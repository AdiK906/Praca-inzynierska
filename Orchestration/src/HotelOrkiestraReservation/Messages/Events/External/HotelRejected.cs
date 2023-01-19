using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace HotelOrkiestraReservation.Messages.Events.External
{
    public class HotelRejected : IRejectedEvent
    {
        public Guid ReservationId{ get; set; }
        public string Reason { get; }
        public string Code { get; }

        public HotelRejected(Guid reservationId, string reason, string code)
        {
            ReservationId = reservationId;
            Reason = reason;
            Code = code;
        }
    }
}
