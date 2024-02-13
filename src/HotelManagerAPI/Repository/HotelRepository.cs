using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;

namespace HotelManagerAPI.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly IHotelManagerAPIContext _context;
        public HotelRepository(IHotelManagerAPIContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            IEnumerable<HotelDto> Hotels = from hotel in _context.Hotels
                                           join city in _context.Cities on hotel.CityId equals city.CityId
                                           select new HotelDto()
                                           {
                                               hotelId = hotel.HotelId,
                                               name = hotel.Name,
                                               address = hotel.Address,
                                               cityId = city.CityId,
                                               cityName = city.Name,
                                               state = city.State
                                           };

            return Hotels.ToList();
        }

        public HotelDto AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();

            var query = from hotelElement in _context.Hotels
                        join city in _context.Cities on hotelElement.CityId equals city.CityId
                        where hotelElement.Name == hotel.Name
                        select new HotelDto()
                        {
                            hotelId = hotelElement.HotelId,
                            name = hotelElement.Name,
                            address = hotelElement.Address,
                            cityId = city.CityId,
                            cityName = city.Name,
                            state = city.State
                        };

            return query.First();
        }
    }
}