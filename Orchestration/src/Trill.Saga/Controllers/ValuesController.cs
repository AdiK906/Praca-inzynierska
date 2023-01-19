using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Convey.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trill.Saga.Commands.External;
using Trill.Saga.Events.External;
using Trill.Saga.Events.External.Reservation;
using Trill.Saga.Models;
using Trill.Saga.Sagas;
using Trill.Saga.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trill.Saga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IMessageBroker _messageBroker;
        public ValuesController(IEventDispatcher eventDispatcher, IMessageBroker messageBroker)
        {
            _eventDispatcher = eventDispatcher;
            _messageBroker = messageBroker;
        }
        //POST api/<ValuesController>

        [HttpPost]
        public void Post(Reservation reservation)
        {
            var @event = new ReservationApproved(Guid.NewGuid(), reservation.TransportId, reservation.HotelId, reservation.ApartamentId);


            //_eventDispatcher.PublishAsync(@event);

            _messageBroker.PublishAsync(@event);


        }


    }
}
