using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace Transport.Choreography.Reservation.Messages.External.Transports
{
    [Message("hotels-choreography")]
    public class TransportReserved : IEvent
    {
        public Guid ReservationId { get; }
        public Guid TransportId { get; }
        public Guid HotelId { get; }
        public Guid AtractionId { get; }

        public TransportReserved(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
        }
    }
}
