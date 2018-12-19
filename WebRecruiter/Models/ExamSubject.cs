using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class ExamSubject
	{
		public short Id { get; set; }
		public string Name { get; set; }
		public short StudyTypeId { get; set; }
		public StudyType StudyType { get; set; }
		public short StudyDegreeId { get; set; }
		public StudyDegree StudyDegree { get; set; }
	}
}