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
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public ContextTest(DbContextOptions<ContextTest> options) : base(options)
    { }

}