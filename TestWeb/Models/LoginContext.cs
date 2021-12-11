using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{
	public class LoginContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }

	}
}