using Atractions.Choreography.Reservation.Models;
using Atractions.Choreography.Reservation.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atractions.Choreography.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtractionController : ControllerBase
    {
        private readonly IAtractionsRepository _atractionRepository;
        public AtractionController(IAtractionsRepository atractionRepository)
        {
            _atractionRepository = atractionRepository;
        }

        [HttpGet]
        public async Task<List<AtractionDto>> GetAllAtractions()
        {
            return await _atractionRepository.GetList();
        }

        [HttpPost("[action]")]
        public async Task<AtractionDto> ReserveAtraction([FromBody]AtractionDto atractionDto)
        {

            return await _atractionRepository.AddAtractionDto(atractionDto);

        }
        [HttpDelete("[action]")]
        public ActionResult<AtractionDto> DeleteAtraction(AtractionDto atractionDto)
        {
            return Ok(_atractionRepository.DeleteAtractionDto(atractionDto));
        }

    }
}
