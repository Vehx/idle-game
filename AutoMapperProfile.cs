using AutoMapper;
using Game.Dtos.Player;
using Game.Models;

namespace Game
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Player, GetPlayerDto>();
            CreateMap<AddPlayerDto, Player>();
        }
    }
}
