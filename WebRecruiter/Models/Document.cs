using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class Document
	{
		public int Id { get; set; }
		public short DocumentTypeId { get; set; }
		public DocumentType DocumentType { get; set; }
		public string SerialNumber { get; set; }
		public DateTime ExpirationDate { get; set; }
	}
}