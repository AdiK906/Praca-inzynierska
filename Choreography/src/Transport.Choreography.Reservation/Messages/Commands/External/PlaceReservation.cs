using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace Transport.Choreography.Reservation.Messages.Commands.External
{
    [Message("transports-choreography")]
    public class PlaceReservation : ICommand
    {
        public Guid ReservationId { get; }
        public Guid TransportId { get; }
        public Guid HotelId { get; }
        public Guid AtractionId { get; }


        public PlaceReservation(Guid reservationId, Guid transportId, Guid hotelId, Guid atractionId)
        {
            ReservationId = reservationId;
            TransportId = transportId;
            HotelId = hotelId;
            AtractionId = atractionId;
        }
    }
}