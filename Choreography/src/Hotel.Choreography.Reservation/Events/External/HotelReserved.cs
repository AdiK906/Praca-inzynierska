using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace Hotel.Choreography.Reservation.Events.External
{
    [Message("atractions-choreography")]
    public class HotelReserved : IEvent 
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }
        public Guid HotelId { get; set; }
        public Guid AtractionId { get; set; }

        public HotelReserved(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
        }
    }
}
