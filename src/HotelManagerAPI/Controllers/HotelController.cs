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

        /// <summary>Lista todos os hotéis. </summary>
        [HttpGet]
        public IActionResult GetHotels()
        {
            var response = _repository.GetHotels();
            return StatusCode(200, response);
        }

        /// <summary>Cadastra um hotel. </summary>
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