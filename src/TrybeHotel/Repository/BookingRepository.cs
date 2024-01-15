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
<<<<<<< HEAD
<<<<<<< HEAD
                        cityName = addedBooking.Room.Hotel.City.Name
=======
                        cityName = addedBooking.Room.Hotel.City.Name,
                        state = addedBooking.Room.Hotel.City.State
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
=======
                        cityName = addedBooking.Room.Hotel.City.Name,
                        state = addedBooking.Room.Hotel.City.State
>>>>>>> faseD/leonardo-martins-trybe-hotel-d
                    }
                }
            };
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            var booking = _context.Bookings.Include(u => u.User).FirstOrDefault(b => b.BookingId == bookingId);

            if (booking.User.Email != email) return null;

            var responseBook = _context.Bookings
                    .Include(b => b.Room).ThenInclude(r => r.Hotel).ThenInclude(h => h.City).FirstOrDefault(b => b.BookingId == bookingId);

            return new BookingResponse()
            {
                bookingId = responseBook.BookingId,
                checkIn = responseBook.CheckIn,
                checkOut = responseBook.CheckOut,
                guestQuant = responseBook.GuestQuant,
                room = new RoomDto()
                {
                    roomId = responseBook.Room.RoomId,
                    name = responseBook.Room.Name,
                    capacity = responseBook.Room.Capacity,
                    image = responseBook.Room.Image,
                    hotel = new HotelDto()
                    {
                        hotelId = responseBook.Room.Hotel.HotelId,
                        name = responseBook.Room.Hotel.Name,
                        address = responseBook.Room.Hotel.Address,
                        cityId = responseBook.Room.Hotel.CityId,
<<<<<<< HEAD
<<<<<<< HEAD
                        cityName = responseBook.Room.Hotel.City.Name
=======
                        cityName = responseBook.Room.Hotel.City.Name,
                        state = responseBook.Room.Hotel.City.State
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
=======
                        cityName = responseBook.Room.Hotel.City.Name,
                        state = responseBook.Room.Hotel.City.State
>>>>>>> faseD/leonardo-martins-trybe-hotel-d
                    }
                }
            };
        }

        public Room GetRoomById(int RoomId)
        {
            var roomToBook = _context.Rooms.FirstOrDefault(r => r.RoomId == RoomId);

            if (roomToBook == null) return null;

            return roomToBook;
        }
    }

}