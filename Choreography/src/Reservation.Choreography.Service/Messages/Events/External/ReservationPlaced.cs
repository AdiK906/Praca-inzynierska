using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace Reservation.Choreography.Service.Messages.Events.External
{
    [Message("transports-choreography")]
    public class ReservationPlaced : IEvent 
    {
        public Guid ReservationId { get;}
        public Guid TransportId { get;}
        public Guid HotelId { get;}
        public Guid AtractionId { get;}

        public ReservationPlaced(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
            
        }
    }
}
