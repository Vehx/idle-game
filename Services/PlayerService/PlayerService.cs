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

            Player player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);

            TimeSpan timeSinceLastUpdate = DateTime.Now - player.LastUpdate;
            player.Money = (int)(player.Money + player.Income * timeSinceLastUpdate.TotalSeconds);
            player.LastUpdate = DateTime.Now;

            _context.Players.Update(player);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
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
                
                // check that player can afford new building
                if (player.Money >= player.Buildings[updatedPlayer.BuildingId].Cost) {

                    // makes sure player doesn't get income from time spent with 0 income
                    if (player.Income == 0)
                        player.LastUpdate = DateTime.Now;

                    var Building = player.Buildings[updatedPlayer.BuildingId];

                    // deduct cost of building from money
                    player.Money -= Building.Cost;

                    // calculate cost for next building
                    Building.Cost = (int)(Building.Cost * Building.CostIncrease);

                    // sets owned to +1 to reflect purchase
                    Building.Owned += 1;

                    // adds buildings income to players income to reflect purchase
                    player.Income += Building.IncomeIncrease;

                    // finally sets players building to updated building and save it to database
                    player.Buildings[updatedPlayer.BuildingId] = Building;
                    _context.Players.Update(player);
                    await _context.SaveChangesAsync();
                }

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