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
<<<<<<< HEAD
<<<<<<< HEAD
=======
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
>>>>>>> faseB/leonardo-martins-trybe-hotel-fase-b
=======
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
=======
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
>>>>>>> faseD/leonardo-martins-trybe-hotel-d
    public ContextTest(DbContextOptions<ContextTest> options) : base(options)
    { }

}