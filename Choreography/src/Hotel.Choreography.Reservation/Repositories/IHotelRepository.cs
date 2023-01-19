using Hotel.Choreography.Reservation.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Choreography.Reservation.Repositories
{
    public interface IHotelRepository
    {
        public Task<HotelDto> AddHotelDto(HotelDto hotelDto);
        public Task<List<HotelDto>> GetList();
        public Task<HotelDto> GetHotelById(Guid id);
        public Task<HotelDto> DeleteHotelDto(HotelDto hotelDto);
    }
}
