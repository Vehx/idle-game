﻿// <auto-generated />
using System;
using Game.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace idle_game.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Game.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BuildingOneCost")
                        .HasColumnType("int");

                    b.Property<double>("BuildingOneCostIncrease")
                        .HasColumnType("double");

                    b.Property<int>("BuildingOneIncomeIncrease")
                        .HasColumnType("int");

                    b.Property<string>("BuildingOneName")
                        .HasColumnType("text");

                    b.Property<int>("BuildingOneOwned")
                        .HasColumnType("int");

                    b.Property<int>("BuildingTwoCost")
                        .HasColumnType("int");

                    b.Property<double>("BuildingTwoCostIncrease")
                        .HasColumnType("double");

                    b.Property<int>("BuildingTwoIncomeIncrease")
                        .HasColumnType("int");

                    b.Property<string>("BuildingTwoName")
                        .HasColumnType("text");

                    b.Property<int>("BuildingTwoOwned")
                        .HasColumnType("int");

                    b.Property<int>("Income")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<double>("MoneyDouble")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
