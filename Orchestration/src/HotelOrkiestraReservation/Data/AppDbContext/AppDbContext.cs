using HotelOrkiestraReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelOrkiestraReservation.Data.AppDbContext
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
