using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace HotelOrkiestraReservation.Messages.Events.External
{
    public class AtractionReserved : IEvent 
    {
        public Guid ReservationId { get; set; }
        public Guid AtractionId { get; set; }
        //public DateTime Date{ get; set; }

        public AtractionReserved(Guid reservationId, Guid atractionId/*, DateTime date*/)
        {
            ReservationId = reservationId;
            AtractionId = atractionId;
            //Date = date;
        }
    }
}
