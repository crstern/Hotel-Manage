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
            Database.SetInitializer<DbCtx>(new Initp());

        }
        public System.Data.Entity.DbSet<Hotel_Manage.Models.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<Hotel_Manage.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Hotel_Manage.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<Hotel_Manage.Models.Reservation> Reservations { get; set; }

    }

    public class Initp : DropCreateDatabaseIfModelChanges<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            Employee emp1 = new Employee { FirstName = "Ionel", LastName = "Popescu", Salary = 2000 };
            Employee emp2 = new Employee { FirstName = "George", LastName = "Toni", Salary = 2700 };
            Employee emp3 = new Employee { FirstName = "Marius", LastName = "Madu", Salary = 2500 };
            Employee emp4 = new Employee { FirstName = "Ionel", LastName = "Dragoi", Salary = 2900 };


            ctx.Employees.Add(emp1);
            ctx.Employees.Add(emp2);
            ctx.Employees.Add(emp3);
            ctx.Employees.Add(emp4);



            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}