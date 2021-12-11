using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{	[Table("Login")]
	public class Customer
	{
		public int Id { get; set; }
		public String UserName { get; set; }
		public String Password { get; set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public String Address { get; set; }
		public String PostalCode { get; set; }
		public String Email { get; set; }
		
	}
}