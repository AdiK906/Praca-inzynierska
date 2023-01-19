using Hotel.Choreography.Reservation.Models;
using Hotel.Choreography.Reservation.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Choreography.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public async Task<List<HotelDto>> GetAllHotels()
        {
            return await _hotelRepository.GetList();  // dodawanie w pamięci sprwadzic jak to robić
        }

        [HttpPost("[action]")]
        public async Task<HotelDto> ReserveHotel([FromBody]HotelDto HotelDto)
        {

            return await _hotelRepository.AddHotelDto(HotelDto);
        }
        [HttpDelete("[action]")]
        public ActionResult<HotelDto> DeleteHotel(HotelDto HotelDto)
        {
            return Ok(_hotelRepository.DeleteHotelDto(HotelDto));
        }

    }
}
