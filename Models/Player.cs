using System.Collections.Generic;

namespace Game.Models
{
    public class Player
    {
        public int Id { get; set;}
        public string Name { get; set;} = "Asha";
        public string Password { get; set;} = "aaaa";
        public int Money { get; set;} = 100;
        public int Income { get; set;} = 0;
        public List<Building> Buildings { get; set;} = new List<Building> { new Building() };
    }

}