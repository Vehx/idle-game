using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Game.Models;
using Game.Services;
// using Game.Dtos.Player;
using System.Collections.Generic;
using System.Linq;

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
        public async Task<IActionResult> AddPlayer(Player newPlayer)
        {
            return Ok(await _playerService.AddPlayer(newPlayer));
        }
        // [HttpGet("GetAll")]
        // public async Task<IActionResult> Get()
        // {
        //     return Ok(await _characterService.GetAllCharacters());
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetSingle(int id)
        // {
        //     return Ok(await _characterService.GetCharacterById(id));
        // }


        // [HttpPost]
        // public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        // {
        //     return Ok(await _characterService.AddCharacter(newCharacter));
        // }

        // [HttpPut]
        // public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        // {
        //     ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updatedCharacter);
        //     if (response.Data == null)
        //     {
        //         return NotFound(response);
        //     }
        //     return Ok(response);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
        //     if (response.Data == null)
        //     {
        //         return NotFound(response);
        //     }
        //     return Ok(response);
        // }
    }
}