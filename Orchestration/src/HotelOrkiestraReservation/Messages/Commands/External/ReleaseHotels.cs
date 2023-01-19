using System.Collections.Generic;
using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace Trill.Saga.Commands.External
{
    public class ReleaseHotels : ICommand
    {
        public Guid ReservationId { get; set; }
        public Guid HotelId { get; set; }

        public ReleaseHotels(Guid reservationId, Guid hotelId)
        {
            ReservationId = reservationId;
            HotelId = hotelId;
        }
    }
}
