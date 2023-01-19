using HotelOrkiestraReservation.Data.AppDbContext;
using HotelOrkiestraReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HotelOrkiestraReservation.Repositories
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
