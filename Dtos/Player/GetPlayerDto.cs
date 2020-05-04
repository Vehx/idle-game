using System.Collections.Generic;
using Game.Models;

namespace Game.Dtos.Player
{
    public class GetPlayerDto
    {
        public int Id { get; set;}
        public string Name { get; set;} = "Asha";
        public int Money { get; set;} = 100;
        public double MoneyDouble { get; set;}
        public int Income { get; set;} = 0;
        public string BuildingOneName {get; set;}
        public int BuildingOneOwned {get; set;}
        public int BuildingOneCost {get; set;}
        public int BuildingOneIncomeIncrease {get; set;}
        public string BuildingTwoName {get; set;}
        public int BuildingTwoOwned {get; set;}
        public int BuildingTwoCost {get; set;}
        public int BuildingTwoIncomeIncrease {get; set;}
    }

}