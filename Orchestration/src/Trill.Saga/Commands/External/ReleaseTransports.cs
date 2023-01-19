using System.Collections.Generic;
using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace Trill.Saga.Commands.External
{
    [Message("transports")]
    public class ReleaseTransports : ICommand
    {
        public Guid ReservationId { get; }
        public Guid TransportId { get; }

        public ReleaseTransports(Guid reservationId, Guid transportId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
        }
    }
}
