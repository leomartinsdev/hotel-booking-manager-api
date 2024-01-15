using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        // 2. Desenvolva o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            IEnumerable<CityDto> Cities = from city in _context.Cities
                                            select new CityDto() { cityId = city.CityId, name = city.Name };
            return Cities.ToList();
        }

        // 3. Desenvolva o endpoint POST /city
=======
        // 4. Refatore o endpoint GET /city
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

        // 2. Refatore o endpoint POST /city
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
        public CityDto AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();

            var query = from cityElement in _context.Cities
                        where cityElement.Name == city.Name
<<<<<<< HEAD
                        select new CityDto() { cityId = cityElement.CityId, name = cityElement.Name };

            return query.First();

        }

=======
                        select new CityDto()
                        {
                            cityId = cityElement.CityId,
                            name = cityElement.Name,
                            state = cityElement.State
                        };

            return query.First();
        }

        // 3. Desenvolva o endpoint PUT /city
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
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
    }
}