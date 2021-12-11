using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{
	public class Order
	{
		public int Id { get; set; }
		public String Item { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		public double Total { get; set; }
		public string pic { get; set; }
	}
}