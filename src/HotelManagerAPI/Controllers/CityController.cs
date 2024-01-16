using Microsoft.AspNetCore.Mvc;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repository;

namespace HotelManagerAPI.Controllers
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

        /// <summary>Lista todas as cidades. </summary>
        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _repository.GetCities();
            return StatusCode(200, cities);
        }

        /// <summary>Cadastra uma cidade. </summary>
        [HttpPost]
        public IActionResult PostCity([FromBody] City city)
        {
            var response = _repository.AddCity(city);
            return StatusCode(201, response);
        }

        /// <summary>Atualiza uma cidade. </summary>
        [HttpPut]
        public IActionResult PutCity([FromBody] City city)
        {
            var response = _repository.UpdateCity(city);
            return StatusCode(200, response);
        }
    }
}