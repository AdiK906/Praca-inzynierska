using System;

namespace Trill.Saga.Sagas
{
    public class PublishAdSagaData
    {
        public Guid ReservationId { get; set; }
        public Guid HotelReservationId{ get; set; }
        public Guid TransportReservationId{ get; set; }
        public Guid AtractionReservationId{ get; set; }
    }
}