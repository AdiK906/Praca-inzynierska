using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using System;

namespace Trill.Saga.Commands.External
{
    [Message("hotels")]
    public class HotelReserve : ICommand
    {
        public Guid ReservationId { get; }
        //public Guid HotelId { get; }

        public HotelReserve(Guid reservationId/*, Guid hotelId*/)
        {
            ReservationId = reservationId;
            //HotelId = hotelId;
        }
    }
}
