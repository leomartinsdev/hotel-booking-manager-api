using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            IEnumerable<HotelDto> Hotels = from hotel in _context.Hotels
                                            join city in _context.Cities on hotel.CityId equals city.CityId
                                            select new HotelDto() { hotelId = hotel.HotelId, name = hotel.Name, address = hotel.Address, cityId = city.CityId, cityName = city.Name };

            return Hotels.ToList();
        }
        
        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();

            var query = from hotelElement in _context.Hotels
                        join city in _context.Cities on hotelElement.CityId equals city.CityId
                        where hotelElement.Name == hotel.Name
                        select new HotelDto() { hotelId = hotelElement.HotelId, name = hotelElement.Name, address = hotelElement.Address, cityId = city.CityId, cityName = city.Name };

            return query.First();
        }
    }
}