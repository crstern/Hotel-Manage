using System;
using System.Collections.Generic;
using System.Data.Entity;
using Hotel_Manage.Models;
using System.Linq;
using System.Web;

namespace Hotel_Manage.Models
{
    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            Database.SetInitializer<DbCtx>(new DropCreateDatabaseIfModelChanges<DbCtx>());
        }
        public DbSet<Room> Rooms { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx context)
        {
            Room room1 = new Room();
            Room room2 = new Room();
            context.Rooms.Add(room1);
            context.Rooms.Add(room2);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}