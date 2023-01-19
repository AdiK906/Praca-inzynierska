using Microsoft.EntityFrameworkCore;
using Transport.Choreography.Reservation.Models;

namespace Transport.Choreography.Reservation.Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ReservationData");
        }
        public DbSet<TransportDto> Transport { get; set; }
    }
}
