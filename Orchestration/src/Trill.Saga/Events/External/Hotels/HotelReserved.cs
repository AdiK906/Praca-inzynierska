using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace Trill.Saga.Events.External.Hotels
{
    [Message("hotels")]
    public class HotelReserved : IEvent
    {
        public Guid ReservationId { get; set; }
        public Guid HotelId { get; set; }

        public HotelReserved(Guid reservationId, Guid hotelId)
        {
            ReservationId = reservationId;
            HotelId = hotelId;
        }
    }
}
