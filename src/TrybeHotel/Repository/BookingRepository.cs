using TrybeHotel.Models;
using TrybeHotel.Dto;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using System.Text.Json;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            var roomToBook = GetRoomById(booking.RoomId);

            if (booking.GuestQuant > roomToBook.Capacity) return null;

            var guest = _context.Users.FirstOrDefault(u => u.Email == email);

            Booking bookingToInsert = new Booking()
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                UserId = guest.UserId,
                RoomId = roomToBook.RoomId,
            };


            _context.Bookings.Add(bookingToInsert);
            _context.SaveChanges();

            var addedBooking = _context.Bookings
                                .Include(b => b.Room).ThenInclude(r => r.Hotel).ThenInclude(h => h.City).FirstOrDefault(b => b.BookingId == bookingToInsert.BookingId);

            return new BookingResponse()
            {
                bookingId = addedBooking.BookingId,
                checkIn = addedBooking.CheckIn,
                checkOut = addedBooking.CheckOut,
                guestQuant = addedBooking.GuestQuant,
                room = new RoomDto()
                {
                    roomId = addedBooking.Room.RoomId,
                    name = addedBooking.Room.Name,
                    capacity = addedBooking.Room.Capacity,
                    image = addedBooking.Room.Image,
                    hotel = new HotelDto()
                    {
                        hotelId = addedBooking.Room.Hotel.HotelId,
                        name = addedBooking.Room.Hotel.Name,
                        address = addedBooking.Room.Hotel.Address,
                        cityId = addedBooking.Room.Hotel.CityId,
                        cityName = addedBooking.Room.Hotel.City.Name
                    }
                }
            };
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomById(int RoomId)
        {
            var roomToBook = _context.Rooms.FirstOrDefault(r => r.RoomId == RoomId);

            if (roomToBook == null) return null;

            return roomToBook;
        }
    }

}