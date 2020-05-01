using AutoMapper;
using Game.Dtos.Player;
using Game.Models;
using Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Game.Services
{
    public class PlayerService : IPlayerService
    {
        // private static List<Player> players = new List<Player> {
        //     new Player(),
        //     new Player { Id = 1, Name = "Cookie" }
        // };
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PlayerService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();

            Player dbPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(dbPlayer);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> AddPlayer(AddPlayerDto newPlayer)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            Player player = _mapper.Map<Player>(newPlayer);

            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto updatedPlayer)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            try
            {
                Player player = await _context.Players.FirstOrDefaultAsync(p => p.Id == updatedPlayer.Id);
                player.Name = updatedPlayer.Name;
                player.Money = updatedPlayer.Money;
                player.Income = updatedPlayer.Income;
                player.Buildings = updatedPlayer.Buildings;

                _context.Players.Update(player);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        // Delete does not work since player id is constrained in database, unsure how to fix
        // public async Task<ServiceResponse<GetPlayerDto>> DeletePlayer(int id)
        // {
        //     ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
        //     try
        //     {
        //         Player player = await _context.Players.FirstAsync(p => p.Id == id);
        //         serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
        //         _context.Players.Remove(player);
        //         await _context.SaveChangesAsync();

        //         serviceResponse.Message = "Player deleted sucessfully.";
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Success = false;
        //         serviceResponse.Message = ex.Message;
        //     }
        //     return serviceResponse;
        // }
    }
}