using System.Threading.Tasks;
using Game.Models;

namespace Game.Services
{
    public interface IPlayerService
    {
        Task<ServiceResponse<Player>> GetPlayerById(int id);
        Task<ServiceResponse<Player>> AddPlayer(Player newPlayer);
        Task<ServiceResponse<Player>> UpdatePlayer(Player player);
    }
}