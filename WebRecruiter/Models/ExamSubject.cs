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
		public short ReceivedPoints { get; set; }
		public bool IsAdvanced { get; set; }
	}
}