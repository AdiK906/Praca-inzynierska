using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace TransportOrkiestraReservation.Messages.Events.External
{
    [Message("ads")]
    public class ReservationApproved : IEvent
    {
        public Guid ReservationId { get; }
        public Guid TransportId { get; }
        public Guid HotelId { get; }
        public Guid AtractionId { get; }

        public ReservationApproved(Guid reservationId, Guid transportId, Guid hotelId, Guid atractiontId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractiontId;
        }
    }
}
