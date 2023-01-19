using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportOrkiestraReservation.Data.AppDbContext;
using TransportOrkiestraReservation.Models;

namespace TransportOrkiestraReservation.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        public async Task<TransportDto> AddTransportDto(TransportDto transportDto)
        {
            using(var context = new AppDbContext())
            {

                context.Transport.AddRange(transportDto);
                await context.SaveChangesAsync();
                return transportDto;
            }
        }
        public async Task<List<TransportDto>> GetList()
        {
            using (var context = new AppDbContext())
            {
                var list = await context.Transport
                    .ToListAsync();
                return list;
            }
        }
        public async Task<TransportDto> GetTransportById(Guid id)
        {
            using (var context = new AppDbContext())
            {
                return await context.Transport.FirstOrDefaultAsync(x => x.ReservationId == id);
            }
        }

        public async Task<TransportDto> DeleteTransportDto(TransportDto transportDto)
        {
            using (var context = new AppDbContext())
            {
                context.Transport.RemoveRange(transportDto);
                await context.SaveChangesAsync();
                return transportDto;
            }
        }

    }
}
