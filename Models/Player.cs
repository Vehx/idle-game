using System;
using System.Collections.Generic;

namespace Game.Models
{
    public class Player
    {
        public int Id { get; set;}
        public string Name { get; set;} = "Asha";
        public string Password { get; set;} = "aaaa";
        public int Money { get; set;} = 100;
        public double MoneyDouble { get; set;} = 100;
        public int Income { get; set;} = 0;
        public DateTime LastUpdate { get; set;} = DateTime.Now;

        public string BuildingOneName { get; set;} = "Farm";
        public int BuildingOneOwned { get; set;} = 0;
        public int BuildingOneCost { get; set;} = 100;
        public int BuildingOneIncomeIncrease { get; set;} = 1;
        public double BuildingOneCostIncrease { get; set;} = 1.2;
        public string BuildingTwoName { get; set;} = "Barn";
        public int BuildingTwoOwned { get; set;} = 0;
        public int BuildingTwoCost { get; set;} = 1000;
        public int BuildingTwoIncomeIncrease { get; set;} = 3;
        public double BuildingTwoCostIncrease { get; set;} = 1.2;
    }

}