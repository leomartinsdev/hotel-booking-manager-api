using Microsoft.AspNetCore.Mvc;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HotelManagerAPI.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _repository;
        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>Busca um quarto pelo Id. </summary>
        [HttpGet("{HotelId}")]
        public IActionResult GetRoom(int HotelId)
        {
            var response = _repository.GetRooms(HotelId);
            return StatusCode(200, response);
        }

        /// <summary>Cadastra um quarto. </summary>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "admin")]
        public IActionResult PostRoom([FromBody] Room room)
        {
            try
            {
                var response = _repository.AddRoom(room);
                return StatusCode(201, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Deleta um quarto. </summary>
        [HttpDelete("{RoomId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "admin")]
        public IActionResult Delete(int RoomId)
        {
            _repository.DeleteRoom(RoomId);
            return StatusCode(204);
        }
    }
}