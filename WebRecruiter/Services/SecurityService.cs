using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRecruiter.Models;
using WebRecruiter.Models.Enums;

namespace WebRecruiter.Services
{
	public class SecurityService
	{
		private readonly ApplicationDbContext _context;
		public SecurityService(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool AssignRoleToUser(string userId, RoleEnum role)
		{

			return true;
		}
	}
}