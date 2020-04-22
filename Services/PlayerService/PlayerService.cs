using Game.Models;
using System.Collections.Generic;
using System.Linq;

namespace Game.Services
{
    public class PlayerService : IPlayerService
    {
        private static List<Player> players = new List<Player> {
            new Player(),
            new Player { Id = 1, Name = "Cookie" }
        };
        public Player AddPlayer(Player newPlayer)
        {
            players.Add(newPlayer);
            return newPlayer;
        }

        public Player GetPlayerById(int id)
        {
            return players.FirstOrDefault(p => p.Id == id);
        }

        public Player UpdatePlayer(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}