using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Hotel.Choreography.Reservation.Events.External;
using Hotel.Choreography.Reservation.Models;
using Hotel.Choreography.Reservation.Repositories;
using Hotel.Choreography.Reservation.Services;


namespace Hotel.Choreography.Reservation.Handlers
{
    public class AtractionRejectedHandler : IEventHandler<AtractionRejected>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IHotelRepository _hotelRepository;
        public AtractionRejectedHandler(IMessageBroker messageBroker, IHotelRepository hotelRepository)
        {
            _messageBroker = messageBroker;
            _hotelRepository = hotelRepository;
        }

        public async Task HandleAsync(AtractionRejected @event)
        {
            HotelDto hotelDto = new HotelDto()
            {
                ReservationId = @event.ReservationId,
                HotelDtoId = @event.HotelId
            };


            await _hotelRepository.DeleteHotelDto(hotelDto);


            await _messageBroker.PublishAsync(new HotelRejected(@event.ReservationId, @event.TransportId,
                    @event.HotelId, @event.AtractionId, "This date is already taken", "Data"));

        }
    }
}