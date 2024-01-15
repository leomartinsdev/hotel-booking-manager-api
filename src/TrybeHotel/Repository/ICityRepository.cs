using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public interface ICityRepository
    {
        IEnumerable<CityDto> GetCities();
        CityDto AddCity(City city);
<<<<<<< HEAD
=======
        CityDto UpdateCity(City city);
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
    }
}