using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }
<<<<<<< HEAD
        
        // 2. Desenvolva o endpoint GET /city.
        [HttpGet]
        public IActionResult GetCities(){
=======

        [HttpGet]
        public IActionResult GetCities()
        {
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
            var cities = _repository.GetCities();
            return StatusCode(200, cities);
        }

<<<<<<< HEAD
        // 3. Desenvolva o endpoint POST /city
        [HttpPost]
        public IActionResult PostCity([FromBody] City city){
            var response = _repository.AddCity(city);
            return StatusCode(201, response);
        }
=======
        [HttpPost]
        public IActionResult PostCity([FromBody] City city)
        {
            var response = _repository.AddCity(city);
            return StatusCode(201, response);
        }

        // 3. Desenvolva o endpoint PUT /city
        [HttpPut]
        public IActionResult PutCity([FromBody] City city)
        {
            var response = _repository.UpdateCity(city);
            return StatusCode(200, response);
        }
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
    }
}