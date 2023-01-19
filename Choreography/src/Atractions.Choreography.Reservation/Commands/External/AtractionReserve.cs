//using Convey.CQRS.Commands;
//using Convey.MessageBrokers;
//using System;

//namespace Atractions.Choreography.Reservation.Commands.External
//{
//    public class AtractionReserve : ICommand
//    {
//        public Guid ReservationId { get; set; }
//        public Guid AtractionId { get; set; }
//        public DayOfWeek DayOfWeek { get; set; }

//        public AtractionReserve(Guid reservationId, Guid atractionId, DayOfWeek dayOfWeek)
//        {
//            ReservationId = reservationId;
//            AtractionId = atractionId;
//            DayOfWeek = dayOfWeek;
//        }
//    }
//}
