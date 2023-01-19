using Microsoft.EntityFrameworkCore;
using Reservation.Choreography.Service.Data.AppDbContext;
using Reservation.Choreography.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Reservation.Choreography.Service.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public async Task<ReservationDto> AddReservationDto(ReservationDto reservationDto)
        {
            using (var context = new AppDbContext())
            {

                context.ReservationDtos.AddRange(reservationDto);
                await context.SaveChangesAsync();
                return reservationDto;
            }
        }
        public async Task<List<ReservationDto>> GetList()
        {
            using (var context = new AppDbContext())
            {
                var list = await context.ReservationDtos
                    .ToListAsync();
                return list;
            }
        }
        public ReservationDto DeleteReservationDto(ReservationDto reservationDto)
        {
            using (var context = new AppDbContext())
            {
                context.ReservationDtos.RemoveRange(reservationDto);
                context.SaveChanges();
                return reservationDto;
            }
        }

    }
}
