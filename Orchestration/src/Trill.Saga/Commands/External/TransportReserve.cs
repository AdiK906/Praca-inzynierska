using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace Trill.Saga.Commands.External
{
    [Message("transports")]
    public class TransportReserve : ICommand
    {
        public Guid ReservationId { get; }
        //public Guid TransportId { get; }

        public TransportReserve(Guid reservationId/*, Guid transportId*/)
        {
            ReservationId = reservationId;
            //TransportId = transportId;
        }
    }
}