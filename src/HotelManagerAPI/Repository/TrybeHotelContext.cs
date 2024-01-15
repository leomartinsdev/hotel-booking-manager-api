using Microsoft.EntityFrameworkCore;
using HotelManagerAPI.Models;

namespace HotelManagerAPI.Repository;
public class HotelManagerAPIContext : DbContext, IHotelManagerAPIContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<User> Users { get; set; }
    public HotelManagerAPIContext(DbContextOptions<HotelManagerAPIContext> options) : base(options)
    {
    }
    public HotelManagerAPIContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=HotelManager;User=SA;Password=HotelManager!;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasOne(b => b.City).WithMany(a => a.Hotels).HasForeignKey(b => b.CityId);
        modelBuilder.Entity<Room>().HasOne(b => b.Hotel).WithMany(a => a.Rooms).HasForeignKey(b => b.HotelId);
        modelBuilder.Entity<Room>().HasMany(b => b.Bookings).WithOne(a => a.Room).HasForeignKey(b => b.RoomId);
        modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(a => a.Bookings).HasForeignKey(b => b.UserId);
    }
}