using System;
using System.Threading.Tasks;
using Atractions.Choreography.Reservation.Models;
using Atractions.Choreography.Reservation.Repositories;
using Atractions.Choreography.Reservation.Services;
using Convey.CQRS.Events;

namespace Atractions.Choreography.Reservation.Events.External.Handlers
{
    public class HotelReservedHandler : IEventHandler<HotelReserved>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IAtractionsRepository _atractionsRepository;
        public HotelReservedHandler(IMessageBroker messageBroker, IAtractionsRepository atractionsRepository)
        {
            _messageBroker = messageBroker;
            _atractionsRepository = atractionsRepository;
        }

        public async Task HandleAsync(HotelReserved @event)
        {
            AtractionDto atractionDto = new AtractionDto()
            {
                ReservationId = @event.ReservationId,
                AtractionDtoId = Guid.NewGuid(),
                DayOfWeek = @event.DayOfWeek
            };


            var list = await _atractionsRepository.GetList();

            if (!list.Exists(x => x.DayOfWeek == DayOfWeek.Sunday))
            {
                await _atractionsRepository.AddAtractionDto(atractionDto);
                await _messageBroker.PublishAsync(new AtractionReserved(@event.ReservationId, @event.TransportId, @event.HotelId, atractionDto.AtractionDtoId));
            }
            else
            {
                await _messageBroker.PublishAsync(new AtractionRejected(@event.ReservationId, @event.TransportId, 
                    @event.HotelId, @event.AtractionId, "This date is already taken", "Data"));
            }


        }
    }
}