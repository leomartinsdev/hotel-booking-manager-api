using Microsoft.AspNetCore.Mvc;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repository;
using HotelManagerAPI.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace HotelManagerAPI.Controllers
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

        /// <summary>Lista todos os usuários. </summary>
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

        /// <summary>Cadastra um usuário. </summary>
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