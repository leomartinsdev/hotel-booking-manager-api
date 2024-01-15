using HotelManagerAPI.Dto;
using HotelManagerAPI.Repository;

namespace HotelManagerAPI.Services
{
    public interface IGeoService
    {
        Task<object> GetGeoStatus();
        Task<List<GeoDtoHotelResponse>> GetHotelsByGeo(GeoDto geoDto, IHotelRepository repository);
    }
}