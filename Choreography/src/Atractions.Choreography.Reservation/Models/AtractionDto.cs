using System;

namespace Atractions.Choreography.Reservation.Models
{
    public class AtractionDto
    {
        public Guid ReservationId { get; set; }
        public Guid AtractionDtoId { get; set; }
        public DayOfWeek DayOfWeek{ get; set; }
    }
}
