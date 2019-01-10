namespace WebRecruiter.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using WebRecruiter.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<WebRecruiter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebRecruiter.Models.ApplicationDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data

			if (!context.Roles.Any(r => r.Name == "AppAdmin"))
			{
				var roles = new List<IRole>();
				var store = new RoleStore<IdentityRole>(context);
				var manager = new RoleManager<IdentityRole>(store);

				var roleAdmin = new IdentityRole { Name = "Admin" };
				var roleUser = new IdentityRole { Name = "User" };

				manager.Create(roleAdmin);
				manager.Create(roleUser);
			}

			if (!context.Users.Any(u => u.UserName == "Creator"))
			{
				var store = new UserStore<ApplicationUser>(context);
				var manager = new UserManager<ApplicationUser>(store);
				var user = new ApplicationUser { UserName = "Creator" };

				manager.Create(user, "Admin123");
				manager.AddToRole(user.Id, "Admin");
			}

		}
	}
}
