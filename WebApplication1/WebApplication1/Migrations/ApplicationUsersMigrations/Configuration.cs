namespace WebApplication1.Migrations.ApplicationUsersMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationUsersMigrations";
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
        {
            var manager =
               new UserManager<ApplicationUser>(
                   new UserStore<ApplicationUser>(context));
            var roleManager =
               new RoleManager<IdentityRole>(
                   new RoleStore<IdentityRole>(context));
            context.Roles.AddOrUpdate(r => r.Name,
               new IdentityRole { Name = "Librarian" }
               );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Member" }
                );

            PasswordHasher ps = new PasswordHasher();
            context.Users.AddOrUpdate(u => u.UserName,
               new ApplicationUser
               {
                   UserName = "einstein.albert@itsligo.ie",
                   Email = "einstein.albert@itsligo.ie",
                   EmailConfirmed = true,
                   DateJoined = DateTime.Now,
                   SecurityStamp = Guid.NewGuid().ToString(),
                   PasswordHash = ps.HashPassword("ITSligo$1")
               });
            context.Users.AddOrUpdate(u => u.UserName,
               new ApplicationUser
               {
                   UserName = "blogs.joe@itsligo.ie",
                   Email = "blogs.joe@itsligo.ie",
                   EmailConfirmed = true,
                   DateJoined = DateTime.Now,
                   SecurityStamp = Guid.NewGuid().ToString(),
                   PasswordHash = ps.HashPassword("ITSligo$2")
               });
            context.SaveChanges();
            //librarian role
            ApplicationUser Librarian = manager.FindByEmail("einstein.albert@itsligo.ie");
            if (Librarian != null)
            {
                manager.AddToRoles(Librarian.Id, new string[] { "Librarian", "Member" });
            }
            //member role
            ApplicationUser Member = manager.FindByEmail("blogs.joe@itsligo.ie");
            if (Member != null)
            {
                manager.AddToRoles(Member.Id, new string[] { "Librarian", "Member" });
            }

        }
    }
}
