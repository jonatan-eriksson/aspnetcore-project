using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspnetcore_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace aspnetcore_project.Data
{
    public class EventDbContext : IdentityDbContext<User>
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        public async Task ResetAndSeedAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();


            await roleManager.CreateAsync(new IdentityRole("Administrator"));
            await roleManager.CreateAsync(new IdentityRole("Organizer"));


            var user = new User { UserName = "admin@events.test", Email = "admin@events.test", EmailConfirmed = true };
            var userCreation = await userManager.CreateAsync(user, "Password1!");

            if (userCreation.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Administrator");
            }


            Event[] events = new Event[] {
                new Event(){
                    Title="Summer camp",
                    Description="Have a fun time chilling in the sun",
                    Place="Colorado springs",
                    Address="515 S Cascade Ave Colorado Springs, CO 80903",
                    Date=DateTime.Now.AddDays(34),
                    SpotsAvailable=234,
                 
                },
                new Event(){
                    Title="Moonhaven",
                    Description="Best lazertag in the world",
                    Place="Blackpark",
                    Address="510 N McPherson Church Rd Fayetteville, NC 28303",
                    Date=DateTime.Now.AddDays(12),
                    SpotsAvailable=23,
                   
                },
            };

            
            await AddRangeAsync(events);
            
            await SaveChangesAsync();
        }
    }
}
