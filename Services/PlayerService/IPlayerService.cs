using System.Threading.Tasks;
using Game.Models;

namespace Game.Services
{
    public interface IPlayerService
    {
        Task<Player> GetPlayerById(int id);
        Task<Player> AddPlayer(Player newPlayer);
        Task<Player> UpdatePlayer(Player player);
    }
}