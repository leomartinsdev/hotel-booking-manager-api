using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
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
<<<<<<< HEAD
                                                 cityName = room.Hotel.City.Name
=======
                                                 cityName = room.Hotel.City.Name,
                                                 state = room.Hotel.City.State
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
                                             }
                                         };

            return Rooms.ToList();
        }

        // 7. Desenvolva o endpoint POST /room
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
<<<<<<< HEAD
                                cityName = roomElement.Hotel.City.Name
=======
                                cityName = roomElement.Hotel.City.Name,
                                state = roomElement.Hotel.City.State
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
                            }
                        };

            return query.First();

        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            var deletedRoom = _context.Rooms.FirstOrDefault(e => e.RoomId == RoomId);

            _context.Rooms.Remove(deletedRoom);
            _context.SaveChanges();
        }
    }
}