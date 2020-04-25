using System.Collections.Generic;
using Game.Models;

namespace Game.Dtos.Player
{
    public class AddPlayerDto
    {
        public string Name { get; set;} = "Asha";
        public int Money { get; set;} = 100;
        public int Income { get; set;} = 0;
        public List<Building> Buildings { get; set;} = new List<Building> { new Building() };
    }

}