using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Transport.Choreography.Reservation;
using Transport.Choreography.Reservation.Events.External;
using Transport.Choreography.Reservation.Messages.Events.External;
using Transport.Choreography.Reservation.Messages.External.Transports;
using Transport.Choreography.Reservation.Models;
using Transport.Choreography.Reservation.Repositories;

namespace Transport.Choreography.Reservation.Handlers
{
    public class HotelRejectedHandler : IEventHandler<HotelRejected>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ITransportRepository _transportRepository;
        public HotelRejectedHandler(IMessageBroker messageBroker, ITransportRepository transportRepository)
        {
            _messageBroker = messageBroker;
            _transportRepository = transportRepository;
        }

        public async Task HandleAsync(HotelRejected @event)
        {
            TransportDto transportDto = new TransportDto()
            {
                ReservationId = @event.ReservationId,
                TransportDtoId = @event.TransportId
            };



            await _transportRepository.DeleteTransportDto(transportDto);

            await Task.CompletedTask;

        }
    }
}