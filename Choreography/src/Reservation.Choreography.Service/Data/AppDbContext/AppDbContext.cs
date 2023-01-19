using Microsoft.EntityFrameworkCore;
using Reservation.Choreography.Service.Models;

namespace Reservation.Choreography.Service.Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TransportData");
        }
        public DbSet<ReservationDto> ReservationDtos { get; set; }
    }
}
