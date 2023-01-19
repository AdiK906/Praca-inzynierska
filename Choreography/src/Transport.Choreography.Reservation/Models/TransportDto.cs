using System;

namespace Transport.Choreography.Reservation.Models
{
    public class TransportDto
    {

        public Guid ReservationId { get; set; }
        public Guid TransportDtoId { get; set; }
        public DayOfWeek DayOfWeek{ get; set; }
    }
}
