using Microsoft.EntityFrameworkCore;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace TrybeHotel.Test;

public class ContextTest : DbContext, ITrybeHotelContext
{
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Hotel> Hotels { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
<<<<<<< HEAD
=======
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
>>>>>>> faseB/leonardo-martins-trybe-hotel-fase-b
    public ContextTest(DbContextOptions<ContextTest> options) : base(options)
    { }

}