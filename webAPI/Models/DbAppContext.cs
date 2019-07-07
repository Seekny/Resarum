using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{   
    public class DbAppContext:DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<EquipmentRooms>().HasKey(sc => new { sc.EquipmentID, sc.RoomID });

            modelBuilder.Entity<EquipmentRooms>()
                .HasOne<Equipment>(sc => sc.Equipment)
                .WithMany(s => s.EquipmentsRooms)
                .HasForeignKey(sc => sc.EquipmentID);


            modelBuilder.Entity<EquipmentRooms>()
                .HasOne<Room>(sc => sc.Room)
                .WithMany(s => s.EquipmentsRooms)
                .HasForeignKey(sc => sc.RoomID);

        }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Room>  Rooms { get; set; }
        public DbSet<Reservation>   Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentRooms> EquipmentsRooms { get; set; }


    }
}
