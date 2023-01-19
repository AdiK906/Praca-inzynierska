using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Transport.Choreography.Reservation;
using Transport.Choreography.Reservation.Messages.Events.External;
using Transport.Choreography.Reservation.Messages.External.Transports;
using Transport.Choreography.Reservation.Models;
using Transport.Choreography.Reservation.Repositories;

namespace Transport.Choreography.Reservation.Handlers
{
    public class ReservationPlacedHandler : IEventHandler<ReservationPlaced>
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ITransportRepository _transportRepository;
        public ReservationPlacedHandler(IMessageBroker messageBroker, ITransportRepository transportRepository)
        {
            _messageBroker = messageBroker;
            _transportRepository = transportRepository;
        }

        public async Task HandleAsync(ReservationPlaced @event)
        {
            TransportDto transportDto = new TransportDto()
            {
                ReservationId = @event.ReservationId,
                TransportDtoId = Guid.NewGuid(),
                DayOfWeek = @event.DayOfWeek
            };


            var list = await _transportRepository.GetList();


            if (!list.Exists(x => x.DayOfWeek == DayOfWeek.Sunday))
            {
                await _messageBroker.PublishAsync(new TransportReserved(@event.ReservationId, transportDto.TransportDtoId, @event.HotelId, @event.AtractionId));
                await _transportRepository.AddTransportDto(transportDto);
            }
            else
            {
                await Task.CompletedTask;
            }


        }
    }
}