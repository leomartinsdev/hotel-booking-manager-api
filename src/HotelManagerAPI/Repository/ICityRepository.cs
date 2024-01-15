using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;

namespace HotelManagerAPI.Repository
{
    public interface ICityRepository
    {
        IEnumerable<CityDto> GetCities();
        CityDto AddCity(City city);
        CityDto UpdateCity(City city);
    }
}