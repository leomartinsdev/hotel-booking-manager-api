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
        // Seeder.SeedUserAdmin(this);
    }
    public HotelManagerAPIContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var server = Environment.GetEnvironmentVariable("DB_HOST") ?? "db";
        var port = Environment.GetEnvironmentVariable("DB_PORT") ?? "1433";
        var user = Environment.GetEnvironmentVariable("DB_USER") ?? "SA";
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "HotelManager01!";
        var database = "HotelManager";

        var connectionString = $"Server={server},{port};Database={database};User={user};Password={password};TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connectionString);
        // AGORA FALTA DAR OS COMPOSES DE NOVO E VER SE FUNCIONA A API E O DB NO AZURE
        // optionsBuilder.UseSqlServer(@"Server=localhost;Database=HotelManager;User=SA;Password=HotelManager01!;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasOne(b => b.City).WithMany(a => a.Hotels).HasForeignKey(b => b.CityId);
        modelBuilder.Entity<Room>().HasOne(b => b.Hotel).WithMany(a => a.Rooms).HasForeignKey(b => b.HotelId);
        modelBuilder.Entity<Room>().HasMany(b => b.Bookings).WithOne(a => a.Room).HasForeignKey(b => b.RoomId);
        modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(a => a.Bookings).HasForeignKey(b => b.UserId);
    }
}