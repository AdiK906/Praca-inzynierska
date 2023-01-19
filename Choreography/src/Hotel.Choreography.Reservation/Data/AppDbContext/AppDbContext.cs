using Hotel.Choreography.Reservation.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Choreography.Reservation.Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "HotelDatabase");
        }
        public DbSet<HotelDto> HotelDtos { get; set; }
    }
}
