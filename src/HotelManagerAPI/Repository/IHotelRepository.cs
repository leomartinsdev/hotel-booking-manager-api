using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;

namespace HotelManagerAPI.Repository
{
    public interface IHotelRepository
    {
        IEnumerable<HotelDto> GetHotels();
        HotelDto AddHotel(Hotel hotel);
    }
}