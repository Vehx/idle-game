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
        public async Task<Player> AddPlayer(Player newPlayer)
        {
            players.Add(newPlayer);
            return newPlayer;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return players.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}