﻿// <auto-generated />
using System;
using HogwartsPotions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HogwartsPotions.Migrations
{
    [DbContext(typeof(HogwartsContext))]
    [Migration("20211125205120_RenameIngredientsColumnInRecipeModel")]
    partial class RenameIngredientsColumnInRecipeModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Ingredient", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PotionID")
                        .HasColumnType("bigint");

                    b.Property<long?>("RecipeID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("PotionID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Potion", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("BrewingStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RecipeID")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Potions");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            BrewingStatus = (byte)0,
                            Name = "Ageing Potion"
                        },
                        new
                        {
                            ID = 2L,
                            BrewingStatus = (byte)0,
                            Name = "Bruise removal paste"
                        });
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Recipe", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("StudentID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("StudentID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Room", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Capacity = 2
                        },
                        new
                        {
                            ID = 2L,
                            Capacity = 2
                        });
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Student", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("HouseType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("PetType")
                        .HasColumnType("tinyint");

                    b.Property<long?>("RoomID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            HouseType = (byte)0,
                            Name = "Hermione Granger",
                            PetType = (byte)1,
                            RoomID = 1L
                        },
                        new
                        {
                            ID = 2L,
                            HouseType = (byte)3,
                            Name = "Draco Malfoy",
                            PetType = (byte)3,
                            RoomID = 2L
                        });
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Ingredient", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Potion", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("PotionID");

                    b.HasOne("HogwartsPotions.Models.Entities.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Potion", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID");

                    b.HasOne("HogwartsPotions.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Recipe");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Recipe", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Student", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Room", "Room")
                        .WithMany("Residents")
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Potion", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Room", b =>
                {
                    b.Navigation("Residents");
                });
#pragma warning restore 612, 618
        }
    }
}
