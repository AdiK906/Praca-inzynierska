using Microsoft.AspNetCore.Mvc;
using Reservation.Choreography.Service.Messages.Commands.External;
using Reservation.Choreography.Service.Messages.Events.External;
using Reservation.Choreography.Service.Models;
using Reservation.Choreography.Service.Repositories;
using Reservation.Choreography.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reservation.Choreography.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IReservationRepository _reservationRepository;
        public ValuesController(IMessageBroker messageBroker, IReservationRepository reservationRepository)
        {
            _messageBroker = messageBroker;
            _reservationRepository = reservationRepository;

        }
        //POST api/<ValuesController>

        [HttpPost]
        public void Post(Reservations reservations)
        {
            //var command = new PlaceReservation(Guid.NewGuid(), reservations.TransportId, reservations.HotelId, reservations.AtractionId);
            var @event = new ReservationPlaced(Guid.NewGuid(), reservations.TransportId, reservations.HotelId, reservations.AtractionId);

            //await _messageBroker.PublishAsync(new ReservationPlaced(command.ReservationId, command.TransportId, command.HotelId, command.AtractionId));
            _messageBroker.PublishAsync(@event);
        }
        [HttpGet]
        public async Task<List<ReservationDto>> GetAllReservations()
        {
            return await _reservationRepository.GetList();
        }

        [HttpPost("[action]")]
        public async Task<ReservationDto> ReserveAtraction([FromBody] ReservationDto atractionDto)
        {

            return await _reservationRepository.AddReservationDto(atractionDto);

        }
        [HttpDelete("[action]")]
        public ActionResult<ReservationDto> DeleteAtraction(ReservationDto atractionDto)
        {
            return Ok(_reservationRepository.DeleteReservationDto(atractionDto));
        }

    }
}
