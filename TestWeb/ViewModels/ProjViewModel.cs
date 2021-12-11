using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.Models; //Must be added without resharper

namespace TestWeb.ViewModels
{
	public class ProjViewModel
	{
		public Proj Proj { get; set; }
		public List<Customer> Customer { get; set; }

	}
}