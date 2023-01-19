using Hotel.Choreography.Reservation.Data.AppDbContext;
using Hotel.Choreography.Reservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hotel.Choreography.Reservation.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<HotelDto> AddHotelDto(HotelDto hotelDto)
        {
            using(var context = new AppDbContext())
            {

                context.HotelDtos.AddRange(hotelDto);
                await context.SaveChangesAsync();
                return hotelDto;
            }
        }
        public async Task<List<HotelDto>> GetList()
        {
            using (var context = new AppDbContext())
            {
                var list = await context.HotelDtos
                    .ToListAsync();
                return list;
            }
        }
        public async Task<HotelDto> GetHotelById(Guid id)
        {
            using (var context = new AppDbContext())
            {
                return await context.HotelDtos.FirstOrDefaultAsync(x => x.ReservationId == id);
            }
        }
        public async Task<HotelDto> DeleteHotelDto(HotelDto hotelDto)
        {
            using (var context = new AppDbContext())
            {
                context.HotelDtos.RemoveRange(hotelDto);
                await context.SaveChangesAsync();
                return hotelDto;
            }
        }

    }
}
