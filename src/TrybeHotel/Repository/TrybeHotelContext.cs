using Microsoft.EntityFrameworkCore;
using TrybeHotel.Models;

namespace TrybeHotel.Repository;
public class TrybeHotelContext : DbContext, ITrybeHotelContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<User> Users { get; set; }
    public TrybeHotelContext(DbContextOptions<TrybeHotelContext> options) : base(options)
    {
    }
    public TrybeHotelContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=TrybeHotel;User=SA;Password=TrybeHotel12!;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasOne(b => b.City).WithMany(a => a.Hotels).HasForeignKey(b => b.CityId);
        modelBuilder.Entity<Room>().HasOne(b => b.Hotel).WithMany(a => a.Rooms).HasForeignKey(b => b.HotelId);
        modelBuilder.Entity<Room>().HasMany(b => b.Bookings).WithOne(a => a.Room).HasForeignKey(b => b.RoomId);
        modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(a => a.Bookings).HasForeignKey(b => b.UserId);
    }
}