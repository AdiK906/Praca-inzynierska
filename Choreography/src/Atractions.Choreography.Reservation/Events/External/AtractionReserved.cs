using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace Atractions.Choreography.Reservation.Events.External
{
    [Message("reservations-choreography")]
    public class AtractionReserved : IEvent
    {
        public Guid ReservationId { get;}
        public Guid TransportId { get; }
        public Guid HotelId { get; }
        public Guid AtractionId { get;}

        public AtractionReserved(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
        }
    }
}
