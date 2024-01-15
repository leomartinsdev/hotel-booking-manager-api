using Microsoft.EntityFrameworkCore;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagerAPI.Test;

public class ContextTest : DbContext, IHotelManagerAPIContext
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