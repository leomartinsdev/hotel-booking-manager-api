using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;

namespace HotelManagerAPI.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly IHotelManagerAPIContext _context;
        public CityRepository(IHotelManagerAPIContext context)
        {
            _context = context;
        }
        public IEnumerable<CityDto> GetCities()
        {
            IEnumerable<CityDto> Cities = from city in _context.Cities
                                          select new CityDto()
                                          {
                                              cityId = city.CityId,
                                              name = city.Name,
                                              state = city.State
                                          };
            return Cities.ToList();
        }

        public CityDto AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();

            var query = from cityElement in _context.Cities
                        where cityElement.Name == city.Name
                        select new CityDto()
                        {
                            cityId = cityElement.CityId,
                            name = cityElement.Name,
                            state = cityElement.State
                        };

            return query.First();
        }

        public CityDto UpdateCity(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();

            var query = from cityElement in _context.Cities
                        where cityElement.Name == city.Name
                        select new CityDto()
                        {
                            cityId = cityElement.CityId,
                            name = cityElement.Name,
                            state = cityElement.State
                        };

            return query.First();
        }
    }
}