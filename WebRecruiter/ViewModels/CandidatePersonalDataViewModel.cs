using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRecruiter.Models;

namespace WebRecruiter.ViewModels
{
	public class CandidatePersonalDataViewModel
	{
		[Required]
		[DisplayName("Imię")]
		public string FirstName { get; set; }

		[DisplayName("Drugie Imię")]
		public string SecondName { get; set; }

		[Required]
		[DisplayName("Nazwisko")]
		public string LastName { get; set; }

		[Required]
		[DisplayName("Data urodzenia")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateOfBirth { get; set; }

		[Required]
		[DisplayName("Miejsce urodzenia")]
		public string PlaceOfBirth { get; set; }

		[DisplayName("Numer telefonu")]
		public string PhoneNumber { get; set; }

		[Required]
		[DisplayName("Pesel")]
		public string Pesel { get; set; }

		[Required]
		[DisplayName("Ulica")]
		public string Street { get; set; }

		[Required]
		[DisplayName("Nr domu")]
		public int HouseNumber { get; set; }

		[DisplayName("Nr mieszkania")]
		public int ApartmentNumber { get; set; }

		[Required]
		[DisplayName("Miasto")]
		public string City { get; set; }

		[Required]
		[DisplayName("Kod kreskowy")]
		public string ZipCode { get; set; }

		[Required]
		[DisplayName("Kraj")]
		public string Country { get; set; }

		[Required]
		[DisplayName("Numer seryjny")]
		public string SerialNumber { get; set; }

		[Required]
		[DisplayName("Data ważności")]
		public DateTime ExpirationDate { get; set; }


		[Required]
		[DisplayName("Typ dokumentu")]
		public short DocumentTypeName { get; set; }
		public IEnumerable<SelectListItem> DocumentTypes { get; set; }




	}
}
