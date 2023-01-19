using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace Trill.Saga.Events.External.Hotels
{
    [Message("hotels")]
    public class HotelRejected : IRejectedEvent
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }
        public string Reason { get; }
        public string Code { get; }

        public HotelRejected(Guid reservationId, Guid transportId, string reason, string code)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            Reason = reason;
            Code = code;
        }
    }
}
