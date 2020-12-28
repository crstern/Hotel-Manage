using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelAPI.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public List<int> Reservations { get; set; }
        public bool CurrentlyBooked { get; set; }
        public int CurrentCustomerId { get; set; }
        public List<int> Jobs { get; set; }
    }

    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            Database.SetInitializer<DbCtx>(new DropCreateDatabaseIfModelChanges<DbCtx>());
        }
        public DbSet<Room> Rooms { get; set; }
    }
}