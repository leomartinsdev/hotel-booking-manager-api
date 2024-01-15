using Microsoft.EntityFrameworkCore;
using TrybeHotel.Models;

namespace TrybeHotel.Repository
{
    public interface ITrybeHotelContext 
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
<<<<<<< HEAD
=======
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
>>>>>>> faseB/leonardo-martins-trybe-hotel-fase-b
        public int SaveChanges();
    }
}
