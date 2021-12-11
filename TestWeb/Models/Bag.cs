using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace TestWeb.Models
{
	[Table("Bag")]
	public class Bag
	{
		public int BagId { get; set; }
		public string BagName { get; set; }
		public float Price { get; set; }
		
	}
}