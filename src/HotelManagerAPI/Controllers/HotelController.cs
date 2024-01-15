using Microsoft.AspNetCore.Mvc;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repository;
using HotelManagerAPI.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HotelManagerAPI.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }

        // 4. Desenvolva o endpoint GET /hotel
        [HttpGet]
        public IActionResult GetHotels()
        {
            var response = _repository.GetHotels();
            return StatusCode(200, response);
        }

        // 5. Desenvolva o endpoint POST /hotel
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "admin")]
        public IActionResult PostHotel([FromBody] Hotel hotel)
        {
            var response = _repository.AddHotel(hotel);
            return StatusCode(201, response);
        }


    }
}