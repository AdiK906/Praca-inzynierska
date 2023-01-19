using System;

namespace Transport.Choreography.Reservation.Models
{
    public class Reservations
    {
        public Guid ReservationId { get; }
        public Guid TransportId { get; }
        public Guid HotelId { get; }
        public Guid AtractionId { get; }

        public Reservations(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
        }
    }
}
