using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using System.Linq;
using HotelOrkiestraReservation.Services;
using HotelOrkiestraReservation.Messages.Commands.External;
using HotelOrkiestraReservation.Messages.Events.External;
using HotelOrkiestraReservation.Models;
using HotelOrkiestraReservation.Repositories;

namespace HotelOrkiestraReservation.Handlers
{
    public class HotelReserveHandler : ICommandHandler<HotelReserve>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IHotelRepository _hotelRepository;
        public HotelReserveHandler(IMessageBroker messageBroker, IHotelRepository hotelRepository)
        {
            _messageBroker = messageBroker;
            _hotelRepository = hotelRepository;
        }

        public async Task HandleAsync(HotelReserve command)
        {

            HotelDto hotelDto = new HotelDto()
            {
                ReservationId = command.ReservationId,
                HotelDtoId = Guid.NewGuid(),
                DayOfWeek = command.DayOfWeek
            };


            var list = await _hotelRepository.GetList();

            if (!list.Exists(x => x.DayOfWeek == DayOfWeek.Sunday))
            {
                await _hotelRepository.AddHotelDto(hotelDto);
                await _messageBroker.PublishAsync(new HotelReserved(command.ReservationId, hotelDto.HotelDtoId));
            }
            else
            {
                await _messageBroker.PublishAsync(new HotelRejected(command.ReservationId, "This date is already taken", "Data"));
            }
        }
    }
}