using AtractionsOrkiestraReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelOrkiestraReservation.Data.AppDbContext
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
