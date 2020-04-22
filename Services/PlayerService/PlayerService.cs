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
        public async Task<ServiceResponse<Player>> AddPlayer(Player newPlayer)
        {
            ServiceResponse<Player> serviceResponse = new ServiceResponse<Player>();
            serviceResponse.Data = newPlayer;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Player>> GetPlayerById(int id)
        {
            ServiceResponse<Player> serviceResponse = new ServiceResponse<Player>();
            serviceResponse.Data = players.FirstOrDefault(p => p.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Player>> UpdatePlayer(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}