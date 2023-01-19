using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace TransportOrkiestraReservation.Messages.Commands.External
{
    public class TransportReserve : ICommand
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public TransportReserve(Guid reservationId, Guid transportId, DayOfWeek dayOfWeek)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            DayOfWeek = dayOfWeek;
        }
    }
}