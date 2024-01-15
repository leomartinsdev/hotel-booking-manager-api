using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;

namespace HotelManagerAPI.Repository
{
    public interface IBookingRepository
    {
        BookingResponse Add(BookingDtoInsert booking, string email);
        Room GetRoomById(int RoomId);
        BookingResponse GetBooking(int bookingId, string email);
    }
}