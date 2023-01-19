using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using TransportOrkiestraReservation.Messages.Commands.External;
using TransportOrkiestraReservation.Messages.Events.External;
using TransportOrkiestraReservation.Models;
using TransportOrkiestraReservation.Repositories;
using TransportOrkiestraReservation.Services;

namespace TransportOrkiestraReservation.Handlers
{
    public class ReleaseTransportsHandler : ICommandHandler<ReleaseTransports>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ITransportRepository _transportRepository;
        public ReleaseTransportsHandler(IMessageBroker messageBroker, ITransportRepository transportRepository)
        {
            _messageBroker = messageBroker;
            _transportRepository = transportRepository;
        }

        public async Task HandleAsync(ReleaseTransports command)
        {

            TransportDto transportDto = new TransportDto()
            {
                ReservationId = command.ReservationId,
                TransportDtoId = command.TransportId
            };

            await _transportRepository.DeleteTransportDto(transportDto);

            await _messageBroker.PublishAsync(new TransportRejected(command.ReservationId, "Hotel or atraction is already reserved", "Data"));
        }
    }
}