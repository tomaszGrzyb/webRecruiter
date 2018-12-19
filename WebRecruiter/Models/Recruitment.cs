using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class Recruitment
	{
		public int Id { get; set; }
		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }
		public short  RecruitmentStatusId { get; set; }
		public RecruitmentStatus RecruitmentStatus { get; set; }
		public int MyProperty { get; set; }

		public DateTime CreatedOn { get; set; }

	}
}