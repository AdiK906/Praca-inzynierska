using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Reservation.Choreography.Service.Messages.Commands.External;
using Reservation.Choreography.Service.Messages.Events.External;
using Reservation.Choreography.Service.Services;

namespace Reservation.Choreography.Service.Handlers
{
    public class PlaceReservationHandler : ICommandHandler<PlaceReservation>
    {
        private readonly IMessageBroker _messageBroker;
        public PlaceReservationHandler(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }
        public async Task HandleAsync(PlaceReservation command)
        {

            await _messageBroker.PublishAsync(new ReservationPlaced(command.ReservationId, command.TransportId, command.HotelId, command.AtractionId));
        }
    }
}
