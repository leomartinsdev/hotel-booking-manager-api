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

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _repository.GetCities();
            return StatusCode(200, cities);
        }

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
    }
}