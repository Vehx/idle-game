using System.Threading.Tasks;
using Game.Dtos.Player;
using Game.Models;

namespace Game.Services
{
    public interface IPlayerService
    {
        Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id);
        Task<ServiceResponse<GetPlayerDto>> AddPlayer(AddPlayerDto newPlayer);
        Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto player);
    }
}