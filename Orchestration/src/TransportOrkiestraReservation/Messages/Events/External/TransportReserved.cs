using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace TransportOrkiestraReservation.Messages.Events.External
{
    public class TransportReserved : IEvent
    {
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }

        public TransportReserved(Guid reservationId, Guid transportId/*, DateTime date*/)
        {
            ReservationId = reservationId;
            TransportId = transportId;
        }
    }
}
