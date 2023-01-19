using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace Trill.Saga.Events.External.Atractions
{
    [Message("atractions")]
    public class AtractionRejected : IRejectedEvent
    {
        public Guid ReservationId { get; set; }
        public Guid HotelId { get; set; }
        public string Reason { get; }
        public string Code { get; }

        public AtractionRejected(Guid reservationId, Guid hotelId, string reason, string code)
        {
            ReservationId = reservationId;
            HotelId = hotelId;
            Reason = reason;
            Code = code;
        }
    }
}
