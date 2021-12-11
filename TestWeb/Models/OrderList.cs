using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{
	public class OrderList
	{
		private List<Order> Orders = new List<Order>();
		public List<Order> ORDER
		{
			get
			{ return Orders; }
		}
		public void AddOrder(Order order){
			Orders.Add(order);

		}
		public int size()
		{
			return Orders.Count;

		}


	}
}