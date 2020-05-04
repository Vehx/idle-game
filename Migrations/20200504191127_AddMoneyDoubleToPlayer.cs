using Microsoft.EntityFrameworkCore.Migrations;

namespace idle_game.Migrations
{
    public partial class AddMoneyDoubleToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MoneyDouble",
                table: "Players",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyDouble",
                table: "Players");
        }
    }
}
