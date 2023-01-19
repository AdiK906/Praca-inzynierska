using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace Transport.Choreography.Reservation.Messages.Events.External
{
    public class ReservationPlaced : IEvent 
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }
        public Guid HotelId { get; set; }
        public Guid AtractionId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public ReservationPlaced(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId, DayOfWeek dayOfWeek)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
            DayOfWeek = dayOfWeek;
            
        }
    }
}
