using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace Trill.Saga.Events.External.Reservation
{
    //[Message("ads")]
    public class ReservationApproved : IEvent
    {
        public Guid ReservationId { get; }
        public Guid TransportId { get; }
        public Guid HotelId { get; }
        public Guid ApartamentId { get; }

        public ReservationApproved(Guid reservationId, Guid transportId, Guid hotelId, Guid apartamentId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            ApartamentId = apartamentId;
        }
    }
}
