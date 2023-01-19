using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Hotel.Choreography.Reservation.Events.External;
using Hotel.Choreography.Reservation.Models;
using Hotel.Choreography.Reservation.Repositories;
using Hotel.Choreography.Reservation.Services;

namespace Hotel.Choreography.Reservation.Handlers
{
    public class TranspordReservedHandler : IEventHandler<TransportReserved>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IHotelRepository _hotelRepository;
        public TranspordReservedHandler(IMessageBroker messageBroker, IHotelRepository hotelRepository)
        {
            _messageBroker = messageBroker;
            _hotelRepository = hotelRepository;
        }

        public async Task HandleAsync(TransportReserved @event)
        {
            HotelDto hotelDto = new HotelDto()
            {
                ReservationId = @event.ReservationId,
                HotelDtoId = Guid.NewGuid(),
                DayOfWeek = @event.DayOfWeek
            };


            var list = await _hotelRepository.GetList();

            if (!list.Exists(x => x.DayOfWeek == DayOfWeek.Sunday))
            {
                await _hotelRepository.AddHotelDto(hotelDto);
                await _messageBroker.PublishAsync(new HotelReserved(@event.ReservationId, @event.TransportId, hotelDto.HotelDtoId, @event.AtractionId));
            }
            else
            {
                await _messageBroker.PublishAsync(new HotelRejected(@event.ReservationId, @event.TransportId, 
                    @event.HotelId, @event.AtractionId, "This date is already taken", "Data"));
            }


        }
    }
}