using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Game.Models;
using Game.Services;
// using Game.Dtos.Building;
using System.Collections.Generic;
using System.Linq;

namespace Game.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        // private readonly ICharacterService _characterService;
        // public BuildingController(ICharacterService characterService)
        // {
        //     _characterService = characterService;

        // }

        private static List<Building> buildings = new List<Building> {
            new Building(),
            new Building { Id = 1, Name = "Barn"}
        };

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

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(buildings.FirstOrDefault(b => b.Id == id));
        }

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