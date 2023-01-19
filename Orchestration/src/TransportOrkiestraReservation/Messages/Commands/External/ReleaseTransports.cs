using System.Collections.Generic;
using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace TransportOrkiestraReservation.Messages.Commands.External
{
    public class ReleaseTransports : ICommand
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }

        public ReleaseTransports(Guid reservationId, Guid transportId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
        }
    }
}
