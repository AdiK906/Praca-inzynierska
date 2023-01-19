using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace Transport.Choreography.Reservation.Events.External
{
    public class HotelRejected : IRejectedEvent
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }
        public Guid HotelId { get; set; }
        public Guid AtractionId { get; set; }
        public string Reason { get; }
        public string Code { get; }

        public HotelRejected(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId, string reason, string code)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
            Reason = reason;
            Code = code;
        }
    }
}
