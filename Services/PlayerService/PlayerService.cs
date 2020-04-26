using AutoMapper;
using Game.Dtos.Player;
using Game.Models;
using System;
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
            Player player = _mapper.Map<Player>(newPlayer);
            player.Id = players.Max(c => c.Id) + 1;
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(players.FirstOrDefault(p => p.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto updatedPlayer)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            try
            {
                Player player = players.FirstOrDefault(p => p.Id == updatedPlayer.Id);
                player.Name = updatedPlayer.Name;
                player.Money = updatedPlayer.Money;
                player.Income = updatedPlayer.Income;
                player.Buildings = updatedPlayer.Buildings;

                serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetPlayerDto>> DeletePlayer(int id)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            try
            {
                Player player = players.First(c => c.Id == id);
                serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
                players.Remove(player);

                serviceResponse.Message = "Player deleted sucessfully.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}