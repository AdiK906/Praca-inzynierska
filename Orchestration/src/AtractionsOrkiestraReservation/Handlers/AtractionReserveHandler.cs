using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using AtractionsOrkiestraReservation.Messages.Commands.External;
using AtractionsOrkiestraReservation.Services;
using AtractionsOrkiestraReservation.Models;
using AtractionsOrkiestraReservation.Repositories;
using AtractionsOrkiestraReservation.Messages.Events.External;
using HotelOrkiestraReservation.Messages.Events.External;

namespace HotelOrkiestraReservation.Handlers
{
    public class AtractionReserveHandler : ICommandHandler<AtractionReserve>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IAtractionsRepository _atractionsRepository;
        public AtractionReserveHandler(IMessageBroker messageBroker, IAtractionsRepository atractionsRepository)
        {
            _messageBroker = messageBroker;
            _atractionsRepository = atractionsRepository;
        }

        public async Task HandleAsync(AtractionReserve command)
        {
            AtractionDto transportDto = new AtractionDto()
            {
                ReservationId = command.ReservationId,
                AtractionDtoId = Guid.NewGuid(),
                DayOfWeek = command.DayOfWeek
            };


            var list = await _atractionsRepository.GetList();

            if (!list.Exists(x => x.DayOfWeek == DayOfWeek.Sunday))
            {
                await _atractionsRepository.AddAtractionDto(transportDto);
                await _messageBroker.PublishAsync(new AtractionReserved(command.ReservationId, Guid.NewGuid()));
            }
            else
            {
                await _messageBroker.PublishAsync(new AtractionRejected(command.ReservationId, "This date is already taken", "Data"));
            }


        }
    }
}