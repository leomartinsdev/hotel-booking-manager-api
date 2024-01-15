using Microsoft.EntityFrameworkCore;
using HotelManagerAPI.Models;

namespace HotelManagerAPI.Repository
{
    public interface IHotelManagerAPIContext 
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public int SaveChanges();
    }
}