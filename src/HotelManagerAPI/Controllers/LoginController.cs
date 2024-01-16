using Microsoft.AspNetCore.Mvc;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repository;
using HotelManagerAPI.Dto;
using HotelManagerAPI.Services;

namespace HotelManagerAPI.Controllers
{
    [ApiController]
    [Route("login")]

    public class LoginController : Controller
    {

        private readonly IUserRepository _repository;
        public LoginController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>Loga um usuário. </summary>
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var validUser = _repository.Login(login);

            if (validUser is null)
            {
                return Unauthorized(new { message = "Incorrect e-mail or password" });
            }

            var token = new TokenGenerator().Generate(validUser);

            return Ok(new { token });
        }
    }
}