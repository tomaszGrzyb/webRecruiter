using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class FieldOfStudy
	{
		public short Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int StudyTypeId { get; set; }
		public StudyType MyProperty { get; set; }

	}
}