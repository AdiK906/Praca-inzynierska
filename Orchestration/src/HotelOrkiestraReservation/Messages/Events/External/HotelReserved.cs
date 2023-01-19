using Chronicle;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;


namespace HotelOrkiestraReservation.Messages.Events.External
{
    public class HotelReserved : IEvent 
    {
        public Guid ReservationId { get; set; }
        public Guid HotelId { get; set; }
        //public DateTime Date{ get; set; }

        public HotelReserved(Guid reservationId, Guid hotelId/*, DateTime date*/)
        {
            ReservationId = reservationId;
            HotelId = hotelId;
            //Date = date;
        }
    }
}
