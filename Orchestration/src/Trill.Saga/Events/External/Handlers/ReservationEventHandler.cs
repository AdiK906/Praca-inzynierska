using System.Threading.Tasks;
using Chronicle;
using Convey.CQRS.Events;
using Trill.Saga.Events.External.Atractions;
using Trill.Saga.Events.External.Hotels;
using Trill.Saga.Events.External.Reservation;
using Trill.Saga.Events.External.Transports;

namespace Trill.Saga.Events.External.Handlers
{
    public class ReservationEventHandler :
        IEventHandler<ReservationApproved>,
        IEventHandler<TransportReserved>,
        IEventHandler<TransportRejected>,
        IEventHandler<HotelReserved>,
        IEventHandler<HotelRejected>,
        IEventHandler<AtractionReserved>,
        IEventHandler<AtractionRejected>
    {
        private readonly ISagaCoordinator _coordinator;

        public ReservationEventHandler(ISagaCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        public Task HandleAsync(ReservationApproved @event) => HandleSagaAsync(@event);
        public Task HandleAsync(TransportReserved @event) => HandleSagaAsync(@event);
        public Task HandleAsync(TransportRejected @event) => HandleSagaAsync(@event);
        public Task HandleAsync(HotelReserved @event) => HandleSagaAsync(@event);
        public Task HandleAsync(HotelRejected @event) => HandleSagaAsync(@event);
        public Task HandleAsync(AtractionReserved @event) => HandleSagaAsync(@event);
        public Task HandleAsync(AtractionRejected @event) => HandleSagaAsync(@event);

        private Task HandleSagaAsync<T>(T @event) where T : class, IEvent
            => _coordinator.ProcessAsync(@event, SagaContext.Empty);
    }
}