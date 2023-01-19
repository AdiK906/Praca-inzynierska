using System.Threading.Tasks;
using Chronicle;
using Trill.Saga.Commands.External;
using Trill.Saga.Events.External.Atractions;
using Trill.Saga.Events.External.Hotels;
using Trill.Saga.Events.External.Reservation;
using Trill.Saga.Events.External.Transports;
using Trill.Saga.Services;

namespace Trill.Saga.Sagas
{
    public class PublishAdSaga : Saga<PublishAdSagaData>,
        ISagaStartAction<ReservationApproved>,
        ISagaAction<TransportReserved>,
        ISagaAction<TransportRejected>,
        ISagaAction<HotelReserved>,
        ISagaAction<HotelRejected>,
        ISagaAction<AtractionReserved>,
        ISagaAction<AtractionRejected>

    {
        private readonly IMessageBroker _messageBroker;

        public PublishAdSaga( IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }
        
        public override SagaId ResolveId(object message, ISagaContext context)
            => message switch
            {
                ReservationApproved m => (SagaId) m.ReservationId.ToString(),
                TransportReserved m => (SagaId) m.ReservationId.ToString(),
                TransportRejected m => (SagaId) m.ReservationId.ToString(),
                HotelReserved m => (SagaId) m.ReservationId.ToString(),
                HotelRejected m => (SagaId) m.ReservationId.ToString(),
                AtractionReserved m => (SagaId) m.ReservationId.ToString(), 
                AtractionRejected m => (SagaId) m.ReservationId.ToString(), 
                _ => base.ResolveId(message, context)
            };

        public async Task HandleAsync(ReservationApproved message, ISagaContext context)  /*--------------------- tu ma byæ reservationID*/
        {
            Data.TransportReservationId = message.ReservationId;
            await _messageBroker.SendAsync(new TransportReserve(message.ReservationId));
        }

        public Task CompensateAsync(ReservationApproved message, ISagaContext context)
        {
            return RejectAsync();
        }


        //TRANSPORTS
        public async Task HandleAsync(TransportReserved message, ISagaContext context)
        {
            Data.TransportReservationId = message.TransportId;
            await _messageBroker.SendAsync(new HotelReserve(message.ReservationId));
        }

        public Task CompensateAsync(TransportReserved message, ISagaContext context)
        {
            return RejectAsync();
        }

        public Task HandleAsync(TransportRejected message, ISagaContext context)
        {
            //Reject();
            return Task.CompletedTask;
        }

        public Task CompensateAsync(TransportRejected message, ISagaContext context)
        {
            return RejectAsync();
        }



        //  HOTELS
        public async Task HandleAsync(HotelReserved message, ISagaContext context)
        {
            Data.HotelReservationId = message.HotelId;
            await _messageBroker.SendAsync(new AtractionReserve(message.ReservationId));
        }

        public Task CompensateAsync(HotelReserved message, ISagaContext context)
        {
            return RejectAsync();
        }
        public async Task HandleAsync(HotelRejected message, ISagaContext context)
        {
            message.TransportId = Data.TransportReservationId;
            await _messageBroker.SendAsync(new ReleaseTransports(message.ReservationId, message.TransportId));
        }

        public Task CompensateAsync(HotelRejected message, ISagaContext context)
        {
            return RejectAsync();
        }


        //ATRACTIONS
        public Task HandleAsync(AtractionReserved message, ISagaContext context)
        {
            Data.AtractionReservationId = message.AtractionId;
            return CompleteAsync();
        }

        public Task CompensateAsync(AtractionReserved message, ISagaContext context)
        {
            return RejectAsync();
        }


        public async Task HandleAsync(AtractionRejected message, ISagaContext context)
        {
            message.HotelId = Data.HotelReservationId;
            await _messageBroker.SendAsync(new ReleaseHotels(message.ReservationId, message.HotelId));
        }

        public Task CompensateAsync(AtractionRejected message, ISagaContext context)
        {
            return RejectAsync();
        }

    }
}