using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using HotelOrkiestraReservation.Messages.Events.External;
using HotelOrkiestraReservation.Models;
using HotelOrkiestraReservation.Repositories;
using HotelOrkiestraReservation.Services;
using Trill.Saga.Commands.External;

namespace HotelOrkiestraReservation.Handlers
{
    public class ReleaseHotelsHandler : ICommandHandler<ReleaseHotels>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IHotelRepository _hotelRepository;
        public ReleaseHotelsHandler(IMessageBroker messageBroker, IHotelRepository hotelRepository)
        {
            _messageBroker = messageBroker;
            _hotelRepository = hotelRepository;
        }

        public async Task HandleAsync(ReleaseHotels command)
        {

            HotelDto hotelDto = new HotelDto()
            {
                ReservationId = command.ReservationId,
                HotelDtoId = command.HotelId
            };

            await _hotelRepository.DeleteHotelDto(hotelDto);

            await _messageBroker.PublishAsync(new HotelRejected(command.ReservationId, "Atraction is already reserved", "Data"));
        }
    }
}