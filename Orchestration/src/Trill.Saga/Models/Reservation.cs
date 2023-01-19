using System;

namespace Trill.Saga.Models
{
    public class Reservation
    {
        public Guid TransportId { get; }
        public Guid HotelId { get; }
        public Guid ApartamentId { get; }

        public Reservation(Guid transportId, Guid hotelId, Guid apartamentId)
        {
            TransportId = transportId;
            HotelId = hotelId;
            ApartamentId = apartamentId;
        }
    }
}
