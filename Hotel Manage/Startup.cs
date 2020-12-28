using Hotel_Manage.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hotel_Manage.Startup))]
namespace Hotel_Manage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdminAndUserRoles();
        }

        private void CreateAdminAndUserRoles()
        {
            var ctx = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(ctx));
            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(ctx));
            // adaugam rolurile pe care le poate avea un utilizator
            // din cadrul aplicatiei
            if (!roleManager.RoleExists("Admin"))
            {
                // adaugam rolul de administrator
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                // se adauga utilizatorul administrator
                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                var adminCreated = userManager.Create(user, "Admin2020!");
                if (adminCreated.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Employee"))
            {
                // adaugati rolul specific aplicatiei voastre
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
                // se adauga utilizatorul
                var user = new ApplicationUser();
                user.UserName = "employee";
                user.Email = "employee@employee.com";
                var employeeCreated = userManager.Create(user, "Employee2020!");
                if (employeeCreated.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Employee");
                }
            }

            if (!roleManager.RoleExists("Customer"))
            {
                // adaugati rolul specific aplicatiei voastre
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
                // se adauga utilizatorul
                var user = new ApplicationUser();
                user.UserName = "customer";
                user.Email = "customer@customer.com";
                var employeeCreated = userManager.Create(user, "Customer2020!");
                if (employeeCreated.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                }
            }
        }
    }
}
