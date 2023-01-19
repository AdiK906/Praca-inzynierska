using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using System;

namespace Trill.Saga.Commands.External
{
    [Message("atractions")]
    public class AtractionReserve : ICommand
    {
        public Guid ReservationId { get; }

        public AtractionReserve(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
