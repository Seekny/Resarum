﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webAPI.Models;

namespace webAPI.Migrations
{
    [DbContext(typeof(DbAppContext))]
    partial class DbAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webAPI.Models.Agency", b =>
                {
                    b.Property<int>("AgencyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("AgencyImage");

                    b.Property<string>("AgencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("AgencyID");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("webAPI.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EquipmentID");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("webAPI.Models.EquipmentRooms", b =>
                {
                    b.Property<int>("EquipmentID");

                    b.Property<int>("RoomID");

                    b.HasKey("EquipmentID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("EquipmentsRooms");
                });

            modelBuilder.Entity("webAPI.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("EndDate");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RoomID");

                    b.Property<DateTimeOffset>("StartDate");

                    b.Property<int>("UserID");

                    b.HasKey("ReservationID");

                    b.HasIndex("RoomID");

                    b.HasIndex("UserID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("webAPI.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgencyID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Floor");

                    b.Property<int>("Places")
                        .HasMaxLength(100);

                    b.Property<string>("RoomImage");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoomID");

                    b.HasIndex("AgencyID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("webAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("webAPI.Models.EquipmentRooms", b =>
                {
                    b.HasOne("webAPI.Models.Equipment", "Equipment")
                        .WithMany("EquipmentsRooms")
                        .HasForeignKey("EquipmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("webAPI.Models.Room", "Room")
                        .WithMany("EquipmentsRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("webAPI.Models.Reservation", b =>
                {
                    b.HasOne("webAPI.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("webAPI.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("webAPI.Models.Room", b =>
                {
                    b.HasOne("webAPI.Models.Agency", "Agency")
                        .WithMany("Rooms")
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
