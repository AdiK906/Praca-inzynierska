using System.Collections.Generic;
using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace Trill.Saga.Commands.External
{
    [Message("hotels")]
    public class ReleaseHotels : ICommand
    {
        public Guid ReservationId { get; }
        public Guid HotelId { get; }

        public ReleaseHotels(Guid reservationId, Guid hotelId)
        {
            ReservationId = reservationId;
            HotelId = hotelId;
        }
    }
}
