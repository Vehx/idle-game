
namespace Game.Models
{
    public class Building
    {
        public int Id { get; set;}
        public string Name { get; set;} = "Farm";
        public int Owned { get; set;} = 0;
        public int Cost { get; set;} = 100;
        public int IncomeIncrease { get; set;} = 1;
        public double CostIncrease { get; set;} = 1.2;
        public IdleUpgrades Upgrade { get; set;} = IdleUpgrades.DoubleIncome;

    }

}