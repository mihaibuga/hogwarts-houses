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
    [Migration("20211124142038_AddDefaultRoomsAndStudents")]
    partial class AddDefaultRoomsAndStudents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            PetType = (byte)1
                        },
                        new
                        {
                            ID = 2L,
                            HouseType = (byte)3,
                            Name = "Draco Malfoy",
                            PetType = (byte)3
                        });
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Student", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Room", "Room")
                        .WithMany("Residents")
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Room", b =>
                {
                    b.Navigation("Residents");
                });
#pragma warning restore 612, 618
        }
    }
}
