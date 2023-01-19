using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Choreography.Reservation.Models;
using Transport.Choreography.Reservation.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Transport.Choreography.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportRepository _transportRepository;
        public TransportController(ITransportRepository transportRepository)
        {
            _transportRepository = transportRepository;
        }

        [HttpGet]
        public async Task<List<TransportDto>> GetAllTransports()
        {
            return await _transportRepository.GetList();
        }

        [HttpPost("[action]")]
        public async Task<TransportDto> ReserveTransports([FromBody]TransportDto transportDto)
        {

            return await _transportRepository.AddTransportDto(transportDto);
        }
        [HttpDelete("[action]")]
        public ActionResult<TransportDto> DeleteTransports(TransportDto transportDto)
        {
            return Ok(_transportRepository.DeleteTransportDto(transportDto));
        }

    }
}
