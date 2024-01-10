using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("user")]

    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "admin")]
        public IActionResult GetUsers()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole is null) return Unauthorized();

            var users = _repository.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDtoInsert user)
        {
            var isRepeteadUser = _repository.GetUserByEmail(user.Email);

            if (isRepeteadUser is not null)
            {
                return Conflict(new { message = "User email already exists" });
            }

            var response = _repository.Add(user);
            return StatusCode(201, response);
        }
    }
}