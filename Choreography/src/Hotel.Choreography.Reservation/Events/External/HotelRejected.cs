using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace Hotel.Choreography.Reservation.Events.External
{
    [Message("transports-choreography")]
    public class HotelRejected : IRejectedEvent 
    {
        public Guid ReservationId { get;}
        public Guid TransportId { get;}
        public Guid HotelId { get;}
        public Guid AtractionId { get;}
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
