using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using TransportOrkiestraReservation.Messages.Commands.External;
using TransportOrkiestraReservation.Models;
using TransportOrkiestraReservation.Services;
using TransportOrkiestraReservation.Repositories;
using TransportOrkiestraReservation.Messages.Events.External;

namespace TransportOrkiestraReservation.Handlers
{
    public class TransportReserveHandler : ICommandHandler<TransportReserve>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ITransportRepository _transportRepository;
        public TransportReserveHandler(IMessageBroker messageBroker, ITransportRepository transportRepository)
        {
            _messageBroker = messageBroker;
            _transportRepository = transportRepository;
        }

        public async Task HandleAsync(TransportReserve command)
        {
            TransportDto transportDto = new TransportDto()
            {
                ReservationId = command.ReservationId,
                TransportDtoId = Guid.NewGuid(),
                DayOfWeek = command.DayOfWeek
            };


            var list = await _transportRepository.GetList();

            if (!list.Exists(x => x.DayOfWeek == DayOfWeek.Sunday))
            {
                await _transportRepository.AddTransportDto(transportDto);
                await _messageBroker.PublishAsync(new TransportReserved(command.ReservationId, transportDto.TransportDtoId));
            }
            else
            {
                await _messageBroker.PublishAsync(new TransportRejected(command.ReservationId, "This date is already taken", "Data"));
            }


        }
    }
}