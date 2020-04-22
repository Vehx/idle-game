using Game.Models;

namespace Game.Services
{
    public interface IPlayerService
    {
        Player GetPlayerById(int id);
        Player AddPlayer(Player newPlayer);
        Player UpdatePlayer(Player player);
    }
}