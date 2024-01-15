using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;

namespace HotelManagerAPI.Repository
{
    public interface IRoomRepository
    {
        IEnumerable<RoomDto> GetRooms(int HotelId);
        RoomDto AddRoom(Room room);

        void DeleteRoom(int RoomId);
    }
}