using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class FieldOfStudyRequirement
	{
		public int Id { get; set; }
		public short FieldOfStudyId { get; set; }
		public short ExamSubjectId { get; set; }
		public int RequiredPoints { get; set; }

	}
}