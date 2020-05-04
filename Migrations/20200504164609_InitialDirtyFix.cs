using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace idle_game.Migrations
{
    public partial class InitialDirtyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Money = table.Column<int>(nullable: false),
                    Income = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    BuildingOneName = table.Column<string>(nullable: true),
                    BuildingOneOwned = table.Column<int>(nullable: false),
                    BuildingOneCost = table.Column<int>(nullable: false),
                    BuildingOneIncomeIncrease = table.Column<int>(nullable: false),
                    BuildingOneCostIncrease = table.Column<double>(nullable: false),
                    BuildingTwoName = table.Column<string>(nullable: true),
                    BuildingTwoOwned = table.Column<int>(nullable: false),
                    BuildingTwoCost = table.Column<int>(nullable: false),
                    BuildingTwoIncomeIncrease = table.Column<int>(nullable: false),
                    BuildingTwoCostIncrease = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
