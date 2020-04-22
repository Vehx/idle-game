using Game.Dtos.Player;
using Game.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Services
{
    public class PlayerService : IPlayerService
    {
        private static List<Player> players = new List<Player> {
            new Player(),
            new Player { Id = 1, Name = "Cookie" }
        };
        public async Task<ServiceResponse<GetPlayerDto>> AddPlayer(AddPlayerDto newPlayer)
        {
            ServiceResponse<Player> serviceResponse = new ServiceResponse<Player>();
            serviceResponse.Data = newPlayer;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            serviceResponse.Data = players.FirstOrDefault(p => p.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto player)
        {
            throw new System.NotImplementedException();
        }
    }
}