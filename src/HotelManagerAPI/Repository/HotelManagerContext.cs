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
        if (!optionsBuilder.IsConfigured)
        {
            string server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
            string user = Environment.GetEnvironmentVariable("DB_USER") ?? "root";
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "123456";
            string port = Environment.GetEnvironmentVariable("DB_PORT") ?? "3308";
            string database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "hotel_manager_db";

            var connectionString = $"Server={server};User Id={user};Password={password};Port={port};Database={database};";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), null);
        }
        /*
        Para usar com SQL Server, use a connection string abaixo.
        To Use with SQL Server, use the connection string below.
        optionsBuilder.UseSqlServer(@"Server={server};Database={database};User={user};Password={password};TrustServerCertificate=True;");
        */
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasOne(b => b.City).WithMany(a => a.Hotels).HasForeignKey(b => b.CityId);
        modelBuilder.Entity<Room>().HasOne(b => b.Hotel).WithMany(a => a.Rooms).HasForeignKey(b => b.HotelId);
        modelBuilder.Entity<Room>().HasMany(b => b.Bookings).WithOne(a => a.Room).HasForeignKey(b => b.RoomId);
        modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(a => a.Bookings).HasForeignKey(b => b.UserId);
    }
}