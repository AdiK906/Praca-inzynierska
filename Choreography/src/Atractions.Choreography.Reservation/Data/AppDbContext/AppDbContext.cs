using Atractions.Choreography.Reservation.Models;
using Microsoft.EntityFrameworkCore;

namespace Atractions.Choreography.Reservation.Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AtractionDatabase");
        }
        public DbSet<AtractionDto> AtractionDtos { get; set; }
    }
}
