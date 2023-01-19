using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace Reservation.Choreography.Service.Messages.Events.External
{
    public class AtractionReserved : IEvent
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }
        public Guid HotelId { get; set; }
        public Guid AtractionId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public AtractionReserved(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId, DayOfWeek dayOfWeek)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
            DayOfWeek = dayOfWeek;
        }
    }
}
