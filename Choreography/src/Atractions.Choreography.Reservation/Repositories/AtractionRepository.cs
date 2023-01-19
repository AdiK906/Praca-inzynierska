using Atractions.Choreography.Reservation.Data.AppDbContext;
using Atractions.Choreography.Reservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Atractions.Choreography.Reservation.Repositories
{
    public class AtractionRepository : IAtractionsRepository
    {
        public async Task<AtractionDto> AddAtractionDto(AtractionDto atractionDto)
        {
            using(var context = new AppDbContext())
            {

                context.AtractionDtos.AddRange(atractionDto);
                await context.SaveChangesAsync();
                return atractionDto;
            }
        }
        public async Task<List<AtractionDto>> GetList()
        {
            using (var context = new AppDbContext())
            {
                var list = await context.AtractionDtos
                    .ToListAsync();
                return list;
            }
        }
        public AtractionDto DeleteAtractionDto(AtractionDto atractionDto)
        {
            using (var context = new AppDbContext())
            {
                context.AtractionDtos.RemoveRange(atractionDto);
                context.SaveChanges();
                return atractionDto;
            }
        }

    }
}
