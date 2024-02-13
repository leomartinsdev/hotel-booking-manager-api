using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;

namespace HotelManagerAPI.Repository
{
    public class Seeder
    {
        public static void SeedUserAdmin(IHotelManagerAPIContext _context)
        {
            try
            {
                var usersCount = _context.Users.Where(u => u.UserType == "admin").Count();
                if (usersCount == 0)
                {
                    _context.Users.Add(new User { Name = "admin", Email = "admin@admin.com", Password = "admin", UserType = "admin" });
                    _context.Users.Add(new User { Name = "Aragorn", Email = "aragorn@hotelapi.com", Password = "aragorn123", UserType = "client" });
                    _context.Users.Add(new User { Name = "Vader", Email = "darth.vader@hotelapi.com", Password = "maytheforce123", UserType = "client" });
                    _context.Users.Add(new User { Name = "Kirk", Email = "captin.kirk@hotelapi.com", Password = "enterprise123", UserType = "client" });
                    _context.Users.Add(new User { Name = "Neo", Email = "matrix@hotelapi.com", Password = "whichpill123", UserType = "client" });

                    var newYorkCity = new City { Name = "New York", State = "NY" };
                    var losAngelesCity = new City { Name = "Los Angeles", State = "CA" };
                    var chicagoCity = new City { Name = "Chicago", State = "IL" };
                    var houstonCity = new City { Name = "Houston", State = "TX" };
                    var miamiCity = new City { Name = "Miami", State = "FL" };

                    _context.Cities.Add(newYorkCity);
                    _context.Cities.Add(losAngelesCity);
                    _context.Cities.Add(chicagoCity);
                    _context.Cities.Add(houstonCity);
                    _context.Cities.Add(miamiCity);

                    _context.SaveChanges();

                    var newYorkHotel = new Hotel { Name = "New York Hilton Midtown", Address = "1335 Avenue of the Americas, New York, NY 10019", CityId = newYorkCity.CityId };
                    var losAngelesHotel = new Hotel { Name = "The Ritz-Carlton, Los Angeles", Address = "900 W Olympic Blvd, Los Angeles, CA 90015", CityId = losAngelesCity.CityId };
                    var chicagoHotel = new Hotel { Name = "Chicago Marriott Downtown Magnificent Mile", Address = "540 N Michigan Ave, Chicago, IL 60611", CityId = chicagoCity.CityId };
                    var houstonHotel = new Hotel { Name = "The Houstonian Hotel, Club & Spa", Address = "111 N Post Oak Ln, Houston, TX 77024", CityId = houstonCity.CityId };
                    var miamiHotel = new Hotel { Name = "Fontainebleau Miami Beach", Address = "4441 Collins Ave, Miami Beach, FL 33140", CityId = miamiCity.CityId };

                    _context.Hotels.Add(newYorkHotel);
                    _context.Hotels.Add(losAngelesHotel);
                    _context.Hotels.Add(chicagoHotel);
                    _context.Hotels.Add(houstonHotel);
                    _context.Hotels.Add(miamiHotel);

                    _context.SaveChanges();

                    _context.Rooms.Add(new Room { Name = "Standard Room", Capacity = 2, Image = "standard_room.jpg", HotelId = newYorkHotel.HotelId });
                    _context.Rooms.Add(new Room { Name = "Deluxe Room", Capacity = 4, Image = "deluxe_room.jpg", HotelId = losAngelesHotel.HotelId });
                    _context.Rooms.Add(new Room { Name = "Executive Suite", Capacity = 6, Image = "suite_room.jpg", HotelId = chicagoHotel.HotelId });
                    _context.Rooms.Add(new Room { Name = "King Suite", Capacity = 4, Image = "king_suite_room.jpg", HotelId = houstonHotel.HotelId });
                    _context.Rooms.Add(new Room { Name = "Oceanfront Room", Capacity = 2, Image = "oceanfront_room.jpg", HotelId = miamiHotel.HotelId });

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
        }
    }
}