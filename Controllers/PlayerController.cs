using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Game.Models;
using Game.Services;
using System.Collections.Generic;
using Game.Dtos.Player;

namespace Game.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _playerService.GetPlayerById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(AddPlayerDto newPlayer)
        {
            return Ok(await _playerService.AddPlayer(newPlayer));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(UpdatePlayerDto updatedPlayer)
        {
            ServiceResponse<GetPlayerDto> response = await _playerService.UpdatePlayer(updatedPlayer);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<GetPlayerDto> response = await _playerService.DeletePlayer(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}