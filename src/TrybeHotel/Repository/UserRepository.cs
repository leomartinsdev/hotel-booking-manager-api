using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
           throw new NotImplementedException();
        }
        public UserDto Add(UserDtoInsert user)
        {
            User userToAdd = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client"
            };

            _context.Users.Add(userToAdd);
            _context.SaveChanges();

            UserDto newUser = new UserDto()
                        {
                            userId = userToAdd.UserId,
                            Name = userToAdd.Name,
                            Email = userToAdd.Email,
                            userType = userToAdd.UserType
                        };

            return newUser;
        }

        public UserDto GetUserByEmail(string userEmail)
        {
            var retrievedUser = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (retrievedUser is null)
            {
                return null;
            }
            else
            {
                return new UserDto()
                {
                    userId = retrievedUser.UserId,
                    Name = retrievedUser.Name,
                    Email = retrievedUser.Email,
                    userType = retrievedUser.UserType
                };
            }
        }

        public IEnumerable<UserDto> GetUsers()
        {
           throw new NotImplementedException();
        }

    }
}