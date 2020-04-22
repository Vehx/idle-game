using AutoMapper;
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
        private readonly IMapper _mapper;

        public PlayerService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetPlayerDto>> AddPlayer(AddPlayerDto newPlayer)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(newPlayer);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(players.FirstOrDefault(p => p.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto player)
        {
            throw new System.NotImplementedException();
        }
    }
}