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
            // int moarMoney = (int)(player.Income * timeSinceLastUpdate.TotalSeconds);
            var moarMoney = player.Money + player.Income * timeSinceLastUpdate.TotalSeconds;
            // player.Money = player.Money + moarMoney;
            player.MoneyDouble = player.Money + player.Income * timeSinceLastUpdate.TotalSeconds;
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
                
                // dirty fix, scary stuff ahead this is your one and only warning :)
                if (updatedPlayer.BuildingId == 0) {
                    if (player.Money >= player.BuildingOneCost) {

                    // makes sure player doesn't get income from time spent with 0 income
                    if (player.Income == 0)
                        player.LastUpdate = DateTime.Now;

                    // var Building = player.Buildings[updatedPlayer.BuildingId];

                    // deduct cost of building from money
                    player.Money -= player.BuildingOneCost;

                    // calculate cost for next building
                    player.BuildingOneCost = (int)(player.BuildingOneCost * player.BuildingOneCostIncrease);

                    // sets owned to +1 to reflect purchase
                    player.BuildingOneOwned += 1;

                    // adds buildings income to players income to reflect purchase
                    player.Income += player.BuildingOneIncomeIncrease;

                    // finally sets player save it to database
                    _context.Players.Update(player);
                    await _context.SaveChangesAsync();
                }
                }
                if (updatedPlayer.BuildingId == 1) {
                    if (player.Money >= player.BuildingTwoCost) {

                        // makes sure player doesn't get income from time spent with 0 income
                        if (player.Income == 0)
                            player.LastUpdate = DateTime.Now;

                        // var Building = player.Buildings[updatedPlayer.BuildingId];

                        // deduct cost of building from money
                        player.Money -= player.BuildingTwoCost;

                        // calculate cost for next building
                        player.BuildingTwoCost = (int)(player.BuildingTwoCost * player.BuildingTwoCostIncrease);

                        // sets owned to +1 to reflect purchase
                        player.BuildingTwoOwned += 1;

                        // adds buildings income to players income to reflect purchase
                        player.Income += player.BuildingTwoIncomeIncrease;

                        // finally sets player save it to database
                        _context.Players.Update(player);
                        await _context.SaveChangesAsync();
                    }
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