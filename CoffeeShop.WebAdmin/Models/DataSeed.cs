using CoffeeShop.DAL.Data;
using CoffeeShop.DAL.DBModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace CoffeeShop.UI.Models
{
    public static class DataSeed
    {
     public static IApplicationBuilder Seed(this IApplicationBuilder app)
        {
            const string adminEmail = "eyvazovanilufer@gmail.com";
            const string adminPassword = "N12345";
            const string superAdminRoleName = "SuperAdmin";

            using (var scope = app.ApplicationServices.CreateScope())
            {

                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                db.Database.Migrate();

                var role = roleManager.FindByNameAsync(superAdminRoleName).Result;
                if (role == null)
                {
                    role = new AppRole
                    {
                        Name = superAdminRoleName
                    };

                    roleManager.CreateAsync(role).Wait();
                }


                var userManeger = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                var adminUser = userManeger.FindByEmailAsync(adminEmail).Result;

                if (adminUser == null)
                {
                    adminUser = new AppUser
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        EmailConfirmed = true
                    };

                    var userResult = userManeger.CreateAsync(adminUser, adminPassword).Result;

                    if (userResult.Succeeded)
                    {
                        userManeger.AddToRoleAsync(adminUser, superAdminRoleName).Wait();
                    }

                }

                if (!db.SiteInfos.Any())
                {
                    db.SiteInfos.Add(new SiteInfo
                    {
                        Name = "CoffeeShop",
                        Header = "We offer a unique coffee house environment unlike any other in N.Y.",
                        Description= "Tailored-Made Coffee",
                        Description1 = "We are excited to introduce our Coffee Shop magna aliqua. Ut enim ad minim veniam, quis nostrud.",
                        Description2 = "The perfect place to enjoy your coffee",
                        Address = "13 Fifth Avenue, New York, NY 10160",
                        PhoneNumber = "929-242-6868",
                        Email = "contact@info.com",
                    });
                    db.SaveChanges();
                }
            }
            return app;
        }
    }
}
