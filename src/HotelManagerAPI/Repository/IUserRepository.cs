using HotelManagerAPI.Models;
using HotelManagerAPI.Dto;

namespace HotelManagerAPI.Repository
{
    public interface IUserRepository
    {
        UserDto GetUserById(int userId);
        UserDto Add(UserDtoInsert user);
        UserDto Login(LoginDto login);
        UserDto GetUserByEmail(string userEmail);
        IEnumerable<UserDto> GetUsers();
    }

}