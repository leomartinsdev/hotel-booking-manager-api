using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerAPI.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly IHotelManagerAPIContext _context;
        public RoomRepository(IHotelManagerAPIContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            IEnumerable<RoomDto> Rooms = from room in _context.Rooms
                                         where room.HotelId == HotelId
                                         select new RoomDto()
                                         {
                                             roomId = room.RoomId,
                                             name = room.Name,
                                             capacity = room.Capacity,
                                             image = room.Image,
                                             hotel = new HotelDto()
                                             {
                                                 hotelId = room.HotelId,
                                                 name = room.Hotel.Name,
                                                 address = room.Hotel.Address,
                                                 cityId = room.Hotel.CityId,
                                                 cityName = room.Hotel.City.Name,
                                                 state = room.Hotel.City.State
                                             }
                                         };

            return Rooms.ToList();
        }

        public RoomDto AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            var query = from roomElement in _context.Rooms
                        where roomElement.Name == room.Name
                        select new RoomDto()
                        {
                            roomId = roomElement.RoomId,
                            name = roomElement.Name,
                            capacity = roomElement.Capacity,
                            image = roomElement.Image,
                            hotel = new HotelDto()
                            {
                                hotelId = roomElement.HotelId,
                                name = roomElement.Hotel.Name,
                                address = roomElement.Hotel.Address,
                                cityId = roomElement.Hotel.CityId,
                                cityName = roomElement.Hotel.City.Name,
                                state = roomElement.Hotel.City.State
                            }
                        };

            return query.First();

        }

        public void DeleteRoom(int RoomId)
        {
            var deletedRoom = _context.Rooms.FirstOrDefault(e => e.RoomId == RoomId);

            _context.Rooms.Remove(deletedRoom);
            _context.SaveChanges();
        }
    }
}