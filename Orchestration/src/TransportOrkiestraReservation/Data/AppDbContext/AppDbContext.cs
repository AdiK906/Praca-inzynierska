using Microsoft.EntityFrameworkCore;
using TransportOrkiestraReservation.Messages.Commands.External;
using TransportOrkiestraReservation.Models;

namespace TransportOrkiestraReservation.Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TransportData");
        }
        public DbSet<TransportDto> Transport { get; set; }
    }
}
