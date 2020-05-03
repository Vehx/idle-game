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
                // player.Name = updatedPlayer.Name;
                // player.Money = updatedPlayer.Money;
                // player.Income = updatedPlayer.Income;
                // player.Buildings = updatedPlayer.Buildings;

                // logic testing groud
                // something get player from database including time stamp of last updated
                
                // check that player can afford new building
                if (player.Money >= player.Buildings[updatedPlayer.BuildingId].Cost) {

                    var Building = player.Buildings[updatedPlayer.BuildingId];

                    // deduct cost of building from money
                    player.Money -= Building.Cost;

                    // calculate cost for next building
                    Building.Cost = (int)(Building.Cost * Building.CostIncrease);

                    // sets owned to +1 to reflect purchase
                    Building.Owned += 1;

                    // adds buildings income to players income to reflect purchase
                    player.Income += Building.IncomeIncrease;

                    // finally sets players building to updated building
                    player.Buildings[updatedPlayer.BuildingId] = Building;
                }
                // player.Buildings = player.Buildings;
                // player.Buildings.Add(player.Buildings[player.Buildings.IndexOf(updatedPlayer.Buildings[0])]);
                // i think this works as intendend, but not 100%
                // player.Income = player.Buildings[updatedPlayer.Buildings[0].Id].Id;


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