using Hotel.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Data
{
    public class HotelReservationDBContext:DbContext
    {
        public HotelReservationDBContext(DbContextOptions<HotelReservationDBContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Models.Domain.Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
