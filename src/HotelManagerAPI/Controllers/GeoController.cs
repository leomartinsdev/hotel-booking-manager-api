using Microsoft.AspNetCore.Mvc;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repository;
using HotelManagerAPI.Dto;
using HotelManagerAPI.Services;
using Microsoft.Data.SqlClient;


namespace HotelManagerAPI.Controllers
{
    [ApiController]
    [Route("geo")]
    public class GeoController : Controller
    {
        private readonly IHotelRepository _repository;
        private readonly IGeoService _geoService;


        public GeoController(IHotelRepository repository, IGeoService geoService)
        {
            _repository = repository;
            _geoService = geoService;
        }

        /// <summary>Retorna o status. </summary>
        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetStatus()
        {
            var status = await _geoService.GetGeoStatus();

            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        /// <summary>Busca a distância de cada hotel. </summary>
        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetHotelsByLocation([FromBody] GeoDto address)
        {
            try
            {
                var hotelsDistances = await _geoService.GetHotelsByGeo(address, _repository);

                return StatusCode(201, hotelsDistances);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}