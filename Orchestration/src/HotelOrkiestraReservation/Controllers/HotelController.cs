using HotelOrkiestraReservation.Models;
using HotelOrkiestraReservation.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelOrkiestraReservation.Controllers
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
        public async Task<HotelDto> ReserveHotel([FromBody]HotelDto hotelDto)
        {

            return await _hotelRepository.AddHotelDto(hotelDto);
        }
        [HttpDelete("[action]")]
        public ActionResult<HotelDto> DeleteHotel(HotelDto hotelDto)
        {
            return Ok(_hotelRepository.DeleteHotelDto(hotelDto));
        }

    }
}
