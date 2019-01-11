﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class Address
	{
		public int Id { get; set; }

		[DisplayName("Ulica")]
		public string Street { get; set; }

		[DisplayName("Nr domu")]
		public int HouseNumber { get; set; }

		[DisplayName("Nr mieszkania")]
		public int ApartmentNumber { get; set; }

		[DisplayName("Miasto")]
		public string City { get; set; }

		[DisplayName("Kod kreskowy")]
		public string ZipCode { get; set; }

		[DisplayName("Kraj")]
		public string Country { get; set; }

	}
}