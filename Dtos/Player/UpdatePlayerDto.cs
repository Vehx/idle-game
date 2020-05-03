using System;
using System.Collections.Generic;
using Game.Models;

namespace Game.Dtos.Player
{
    public class UpdatePlayerDto
    {
        public int Id { get; set;}
        public int BuildingId { get; set;}
        public DateTime LastUpdate { get; set;} = DateTime.Now;
    }

}