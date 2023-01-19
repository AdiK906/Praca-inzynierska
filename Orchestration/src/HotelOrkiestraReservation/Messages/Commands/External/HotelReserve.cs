using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using System;

namespace HotelOrkiestraReservation.Messages.Commands.External
{
    public class HotelReserve : ICommand
    {
        public Guid ReservationId { get; set; }
        public Guid HotelId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public HotelReserve(Guid reservationId, Guid hotelId, DayOfWeek dayOfWeek)
        {
            ReservationId = reservationId;
            HotelId = hotelId;
            DayOfWeek = dayOfWeek;
        }
    }
}
