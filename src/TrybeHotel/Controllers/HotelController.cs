using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
>>>>>>> faseB/leonardo-martins-trybe-hotel-fase-b

namespace TrybeHotel.Controllers
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
<<<<<<< HEAD
        
        // 4. Desenvolva o endpoint GET /hotel
        [HttpGet]
        public IActionResult GetHotels(){
=======

        // 4. Desenvolva o endpoint GET /hotel
        [HttpGet]
        public IActionResult GetHotels()
        {
>>>>>>> faseB/leonardo-martins-trybe-hotel-fase-b
            var response = _repository.GetHotels();
            return StatusCode(200, response);
        }

        // 5. Desenvolva o endpoint POST /hotel
        [HttpPost]
<<<<<<< HEAD
        public IActionResult PostHotel([FromBody] Hotel hotel){
=======
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "admin")]
        public IActionResult PostHotel([FromBody] Hotel hotel)
        {
>>>>>>> faseB/leonardo-martins-trybe-hotel-fase-b
            var response = _repository.AddHotel(hotel);
            return StatusCode(201, response);
        }


    }
}