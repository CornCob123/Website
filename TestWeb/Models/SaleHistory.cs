using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{
	[Table("SalesHistory")]
	public class SaleHistory
	{	[Key]
		public int SaleID { get; set; }
		public int BagID{ get; set; }
		public int UserID { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public double Total { get; set; }

	}
}