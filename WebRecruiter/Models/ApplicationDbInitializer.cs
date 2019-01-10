using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			//InitializeRoles(context);
			
	
			base.Seed(context);
		}

		private void InitializeRoles(ApplicationDbContext context)
		{
			var roles = new List<IRole>();
			var store = new RoleStore<IdentityRole>(context);
			var manager = new RoleManager<IdentityRole>(store);

			var roleAdmin = new IdentityRole { Name = "Admin" };
			var roleUser = new IdentityRole { Name = "User" };

			manager.Create(roleAdmin);
			manager.Create(roleUser);
		}

	
	}
}