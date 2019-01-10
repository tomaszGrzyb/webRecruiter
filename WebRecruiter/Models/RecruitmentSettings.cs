using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class RecruitmentSettings
	{
		public short Id { get; set; }		
		public DateTime RecruitmentStartDate  { get; set; }
		public DateTime RecruitmentEndDate  { get; set; }
		public DateTime UpdatedOn { get; set; }
		public ApplicationUser UpdatedBy { get; set; }
		

	}
}