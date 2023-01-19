using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace Hotel.Choreography.Reservation.Events.External
{
    public class TransportReserved : IEvent
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }
        public Guid HotelId { get; set; }
        public Guid AtractionId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public TransportReserved(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId, DayOfWeek dayOfWeek)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
            DayOfWeek = dayOfWeek;
        }
    }
}
