using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class Candidate
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string PlaceOfBirth { get; set; }
		public string PhoneNumber { get; set; }
		public string Pesel { get; set; }
		public int AddressId { get; set; }
		public Address Address { get; set; }
		public int DocumentId { get; set; }
		public Document Document { get; set; }

	}
}