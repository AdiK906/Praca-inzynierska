using System;

namespace Hotel.Choreography.Reservation.Models
{
    public class HotelDto
    {
        public Guid ReservationId { get; set; }
        public Guid HotelDtoId { get; set; }
        public DayOfWeek DayOfWeek{ get; set; }
    }
}
