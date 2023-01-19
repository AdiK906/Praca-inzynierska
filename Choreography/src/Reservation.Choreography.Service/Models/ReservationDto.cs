using System;

namespace Reservation.Choreography.Service.Models
{
    public class ReservationDto
    {
        public Guid PrimaryKey { get; set; }
        public Guid ReservationId { get; set; }
        public Guid TransportId { get; set; }
        public Guid HotelId { get; set; }
        public Guid AtractionId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

    }
}
