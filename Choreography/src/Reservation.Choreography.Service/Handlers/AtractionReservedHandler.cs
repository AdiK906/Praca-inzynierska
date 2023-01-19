using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Reservation.Choreography.Service.Messages.Events.External;
using Reservation.Choreography.Service.Models;
using Reservation.Choreography.Service.Repositories;

namespace Reservation.Choreography.Service.Handlers
{
    public class AtractionReservedHandler : IEventHandler<AtractionReserved>
    {
        //private readonly IReservationRepository _reservationRepository;
        public AtractionReservedHandler(/*IReservationRepository reservationRepository*/)
        {
            //_reservationRepository = reservationRepository;
        }

        public async Task HandleAsync(AtractionReserved @event)
        {
            ReservationDto atractionDto = new ReservationDto()
            {
                ReservationId = @event.ReservationId,
                TransportId = @event.TransportId,
                HotelId = @event.HotelId,
                AtractionId = @event.AtractionId,
            };

            await Task.CompletedTask;
        }
    }
}