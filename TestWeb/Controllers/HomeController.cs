using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;

namespace TestWeb.Controllers
{
	public class HomeController : Controller
	{
		
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			//ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "My contact page.";

			return View();
		}
		public ActionResult Projects()
		{
			//ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Login()
		{
			//ViewBag.Message = "My contact page.";
			Customer customer = new Customer()
			{
				Id = 1,
				UserName = "",
				Password = "",
				FirstName = "",
				LastName = ""

			};

			return View(customer);
		}
		
		[HttpPost]
		public ActionResult Login(Customer u)
		{
			Boolean loginStatus = false;
			string user = u.UserName;
			string pass = u.Password;
			using (LoginContext loginContext = new LoginContext()) {
				List<Customer> numbers = new List<Customer>();
				foreach (Customer item in loginContext.Customers)
				{
					if (item.UserName.ToUpper().Equals(user.ToUpper()) && item.Password.Equals(pass)) {

						ViewBag.Message = "Login Success";
						loginStatus = true;
						Session["UserID"] = u.Id;
						return RedirectToAction("LoggedInAfter", "Home");
					}
					numbers.Add(item);

				}
				if (loginStatus ==false) {
					ViewBag.Message = "Login Failed, Incorrect User or password";
				}
			}
			Customer customer = new Customer()
			{
				Id = 1,
				UserName = user,
				Password = pass,
				FirstName = "John",
				LastName = "Cena"

			};
			return View(customer);
		}
		public ActionResult StockApp()
		{
			//ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Cartooniser()
		{
			//ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult SignUp()
		{
			//ViewBag.Message = "Your contact page.";
			Customer customer = new Customer()
			{
				Id = 1,
				UserName = "",
				Password = "",
				FirstName = "",
				LastName = "",
				Address = " ",
				PostalCode = "",
				Email = ""

			};
			return View(customer);
		}
		[HttpPost]
		public ActionResult SignUp(Customer u)
		{
			//ViewBag.Message = "Your contact page.";
			Customer customer = new Customer()
			{
				Id = 1,
				UserName = u.UserName,
				Password = u.Password,
				FirstName = u.FirstName,
				LastName = u.LastName,
				Address = u.Address,
				PostalCode = u.PostalCode,
				Email = u.Email

			};
			//if (ModelState.IsValid) {
				using (LoginContext loginContext = new LoginContext()) {
					loginContext.Customers.Add(customer);
					loginContext.SaveChanges();


				}
				//ModelState.Clear();

			//}
			ViewBag.Message = "Successfully Registered";
			return View(customer);
		}
		public ActionResult LoggedIn()
		{
			
			Customer customer = new Customer()
			{
				Id = 1,
				UserName = "",
				Password = "",
				FirstName = "",
				LastName = "",
				Address = "",
				PostalCode = "",
				Email = ""

			};
		
			LoginContext loginContext = new LoginContext();

			//if (loginContext.Customers != null)
			//{
				Customer customer1 = loginContext.Customers.Single(Cus => Cus.Id == 1);
			Debug.WriteLine("ID " + customer1.Id);
			Debug.WriteLine("UserName " + customer1.UserName);
			Debug.WriteLine("Password " + customer1.Password);
			Debug.WriteLine("First Name " + customer1.FirstName);
			Debug.WriteLine("Last Name " + customer1.LastName);
			//}
			return View();
		}
		public ActionResult LoggedInAfter()
		{
			Customer customer = new Customer()
			{
				Id = 1,
				UserName = "Johncena123",
				Password = "fffffffffffff",
				FirstName = "John",
				LastName = "Cena",
				Address="Kings street",
				PostalCode="89995",
				Email="Johncena@gmail.com"

			};
			//LoginContext loginContext = new LoginContext();
			//List<Customer> numbers = new List<Customer>();
			//foreach (Customer item in loginContext.Customers)
			//{
			//	numbers.Add(item);
			//}
			//Customer customer1 = loginContext.Customers.Single(Cus => Cus.Id == 2);
			
			return View();
			//return Content("You have Logged In ");

		}
		[HttpPost]
		public ActionResult LoggedInAfter(FormCollection fc, string btn)
		{
			int qty = 0;
			int count = 0;
			String item = "";
			double price = 0;
			int Qty = 0;
			OrderList d = new OrderList();
			if (btn == "btn1")
			{
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order() {
					Id=1,
					Item = "Zephyr Red",
					Price=39.99,
					Quantity=qty,
					Total= qty* 39.99,
					pic="bag1"
				};
				
				d.AddOrder(O);
				count=d.ORDER.Count;
				item = d.ORDER[count-1].Item;
				price = d.ORDER[count-1].Price;
				Qty = d.ORDER[count-1].Quantity;
				
				Session["order1Id"] = O.Id;
				Session["order1Item"] = O.Item;
				Session["order1Price"] = O.Price;
				Session["order1Qty"] = O.Quantity;
				Session["order1Total"] = O.Total;
				Session["orderBtn1"] = 1;
				Session["order1Pic"] = O.pic;
				using (StreamWriter writer = new StreamWriter(Server.MapPath("/OrderData/order.txt"), true))
				{
					writer.WriteLine(item);
					writer.WriteLine(price);
					writer.WriteLine(Qty);
				}
			}
			else if (btn == "btn2") {
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 2,
					Item = "Pikachu Red",
					Price = 49.99,
					Quantity = qty,
					Total=49.99*qty,
					pic = "bag2"
				};
				
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order2Id"] = O.Id;
				Session["order2Item"] = O.Item;
				Session["order2Price"] = O.Price;
				Session["order2Qty"] = O.Quantity;
				Session["order2Total"] = O.Total;
				Session["orderBtn2"] = 2;
				Session["order2Pic"] = O.pic;
			}
			else if (btn == "btn3")
			{
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 3,
					Item = "Superz",
					Price = 59.99,
					Quantity = qty,
					Total= 59.99*qty,
					pic = "bag3"
				};
			
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order3Id"] = O.Id;
				Session["order3Item"] = O.Item;
				Session["order3Price"] = O.Price;
				Session["order3Qty"] = O.Quantity;
				Session["order3Total"] = O.Total;
				Session["orderBtn3"] = 3;
				Session["order3Pic"] = O.pic;
			}
			else if (btn == "btn4")
			{
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 4,
					Item = "Victori",
					Price = 45.99,
					Quantity = qty,
					Total=45.99*qty,
					pic = "bag4"
				};
				
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order4Id"] = O.Id;
				Session["order4Item"] = O.Item;
				Session["order4Price"] = O.Price;
				Session["order4Qty"] = O.Quantity;
				Session["order4Total"] = O.Total;
				Session["orderBtn4"] = 4;
				Session["order4Pic"] = O.pic;
			}
			else if (btn == "btn5")
			{
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 5,
					Item = "Green Coco",
					Price = 57.99,
					Quantity = qty,
					Total=qty*57.99,
					pic = "bag11"
				};
				
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order5Id"] = O.Id;
				Session["order5Item"] = O.Item;
				Session["order5Price"] = O.Price;
				Session["order5Qty"] = O.Quantity;
				Session["order5Total"] = O.Total;
				Session["orderBtn5"] = 5;
				Session["order5Pic"] = O.pic;
			}
			else if (btn == "btn6")
			{
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 6,
					Item = "CrayonCar",
					Price = 37.99,
					Quantity = qty,
					Total=qty*37.99,
					pic = "bag6"
				};
			
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order6Id"] = O.Id;
				Session["order6Item"] = O.Item;
				Session["order6Price"] = O.Price;
				Session["order6Qty"] = O.Quantity;
				Session["order6Total"] = O.Total;
				Session["orderBtn6"] = 6;
				Session["order6Pic"] = O.pic;
			}
			else if (btn == "btn7")
			{
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 7,
					Item = "Lightning",
					Price = 38.99,
					Quantity = qty,
					Total=38.99*qty,
					pic = "bag7"
				};
				
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order7Id"] = O.Id;
				Session["order7Item"] = O.Item;
				Session["order7Price"] = O.Price;
				Session["order7Qty"] = O.Quantity;
				Session["order7Total"] = O.Total;
				Session["orderBtn7"] = 7;
				Session["order7Pic"] = O.pic;
			}
			else if (btn == "btn8")
			{
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 8,
					Item = "Druning grey",
					Price = 54.99,
					Quantity = qty,
					Total=qty*54.99,
					pic = "bag8"
				};
				
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order8Id"] = O.Id;
				Session["order8Item"] = O.Item;
				Session["order8Price"] = O.Price;
				Session["order8Qty"] = O.Quantity;
				Session["order8Total"] = O.Total;
				Session["orderBtn8"] = 8;
				Session["order8Pic"] = O.pic;
			}
			else if (btn == "btn9")
			{
				
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 9,
					Item = "Vitary",
					Price = 50.99,
					Quantity = qty,
					Total=50.99*qty,
					pic = "bag9"
				};
			
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order9Id"] = O.Id;
				Session["order9Item"] = O.Item;
				Session["order9Price"] = O.Price;
				Session["order9Qty"] = O.Quantity;
				Session["order9Total"] = O.Total;
				Session["orderBtn9"] = 9;
				Session["order9Pic"] = O.pic;
			}
			else if (btn == "btn10")
			{
			
				if (Int32.TryParse(fc["Quantity"], out qty))
				{
					qty = Int32.Parse(fc["Quantity"]);
					// you know that the parsing attempt
					// was successful
				}
				Order O = new Order()
				{
					Id = 10,
					Item = "Queens",
					Price = 40.99,
					Quantity = qty,
					Total=40.99*qty,
					pic = "bag10"
				};
				
				d.AddOrder(O);
				count = d.ORDER.Count;
				item = d.ORDER[count - 1].Item;
				price = d.ORDER[count - 1].Price;
				Qty = d.ORDER[count - 1].Quantity;
				Session["order10Id"] = O.Id;
				Session["order10Item"] = O.Item;
				Session["order10Price"] = O.Price;
				Session["order10Qty"] = O.Quantity;
				Session["order10Total"] = O.Total;
				Session["orderBtn10"] = 10;
				Session["order10Pic"] = O.pic;

			}
			Customer customer = new Customer()
			{
				Id = 1,
				UserName = "Johncena123",
				Password = "fffffgggg",
				FirstName = "John",
				LastName = "Cena",
				Address = "Kings street",
				PostalCode = "89995",
				Email = "Johncena@gmail.com"

			};
			if (Qty != 0)
			{
				ViewBag.Message = "quantity=" + fc["Quantity"] + "Size =" + count + "Item " + item + "Price " + price + "QTY " + Qty;
			}
			else {
				ViewBag.Message = "quantity=";
			}
			

			return View();
			

		}

		public ActionResult ShoppingCart()
		{
			OrderList o = new OrderList();
			List<Order>OD= new List<Order>();
			Order l = new Order()
			{
				Id = 1,
				Item = "",
				Price = 0,
				Quantity = 2,
				Total = 0

			};
			if (Session["orderBtn1"]!=null&&(int)Session["orderBtn1"] == 1 )
			{
				l = new Order();
				l.Id = (int)Session["order1Id"];
				l.Item = (string)Session["order1Item"];
				l.Price = (double)Session["order1Price"];
				l.Quantity = (int)Session["order1Qty"];
				l.Total= (double)Session["order1Total"];
				l.pic = (string)Session["order1Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}


			

			if (Session["orderBtn2"] != null && (int)Session["orderBtn2"] == 2 )
			{
				l = new Order();
				l.Id = (int)Session["order2Id"];
				l.Item = (string)Session["order2Item"];
				l.Price = (double)Session["order2Price"];
				l.Quantity = (int)Session["order2Qty"];
				l.Total = (double)Session["order2Total"];
				l.pic = (string)Session["order2Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			if (Session["orderBtn3"] != null && (int)Session["orderBtn3"] == 3 )
			{
				l = new Order();
				l.Id = (int)Session["order3Id"];
				l.Item = (string)Session["order3Item"];
				l.Price = (double)Session["order3Price"];
				l.Quantity = (int)Session["order3Qty"];
				l.Total = (double)Session["order3Total"];
				l.pic = (string)Session["order3Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			if (Session["orderBtn4"] != null && (int)Session["orderBtn4"] == 4 )
			{
				l = new Order();
				l.Id = (int)Session["order4Id"];
				l.Item = (string)Session["order4Item"];
				l.Price = (double)Session["order4Price"];
				l.Quantity = (int)Session["order4Qty"];
				l.Total = (double)Session["order4Total"];
				l.pic = (string)Session["order4Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			if (Session["orderBtn5"] != null && (int)Session["orderBtn5"] == 5 )
			{
				l = new Order();
				l.Id = (int)Session["order5Id"];
				l.Item = (string)Session["order5Item"];
				l.Price = (double)Session["order5Price"];
				l.Quantity = (int)Session["order5Qty"];
				l.Total = (double)Session["order5Total"];
				l.pic = (string)Session["order5Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			if (Session["orderBtn6"] != null && (int)Session["orderBtn6"] == 6 )
			{
				l = new Order();
				l.Id = (int)Session["order6Id"];
				l.Item = (string)Session["order6Item"];
				l.Price = (double)Session["order6Price"];
				l.Quantity = (int)Session["order6Qty"];
				l.Total = (double)Session["order6Total"];
				l.pic = (string)Session["order6Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			if (Session["orderBtn7"] != null && (int)Session["orderBtn7"] == 7 )
			{
				l = new Order();
				l.Id = (int)Session["order7Id"];
				l.Item = (string)Session["order7Item"];
				l.Price = (double)Session["order7Price"];
				l.Quantity = (int)Session["order7Qty"];
				l.Total = (double)Session["order7Total"];
				l.pic = (string)Session["order7Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			if (Session["orderBtn8"] != null && (int)Session["orderBtn8"] == 8 )
			{
				l = new Order();
				l.Id = (int)Session["order8Id"];
				l.Item = (string)Session["order8Item"];
				l.Price = (double)Session["order8Price"];
				l.Quantity = (int)Session["order8Qty"];
				l.Total = (double)Session["order8Total"];
				l.pic = (string)Session["order8Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			if (Session["orderBtn9"] != null && (int)Session["orderBtn9"] == 9 )
			{
				l = new Order();
				l.Id = (int)Session["order9Id"];
				l.Item = (string)Session["order9Item"];
				l.Price = (double)Session["order9Price"];
				l.Quantity = (int)Session["order9Qty"];
				l.Total = (double)Session["order9Total"];
				l.pic = (string)Session["order9Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			if (Session["orderBtn10"] != null && (int)Session["orderBtn10"] == 10 )
			{
				l = new Order();
				l.Id = (int)Session["order1Id"];
				l.Item = (string)Session["order10Item"];
				l.Price = (double)Session["order10Price"];
				l.Quantity = (int)Session["order10Qty"];
				l.Total = (double)Session["order10Total"];
				l.pic = (string)Session["order10Pic"];
				o.AddOrder(l);
				OD.Add(l);
			}
			
			Session["BagId"] = l.Id;
			Session["Price"] = l.Price;
			Session["Quantity"] = l.Quantity;
			Session["Total"] = l.Total;
			//return View(l);
			//return View(o);
			return View(OD);
			//int count = o.size();
			//for (int i=0;i< count; i++)
			//	{
			//		return View(o.ORDER[i]);

			//	}
		}

		public ActionResult Payment()
		{

			SaleHistory u = new SaleHistory() {
			SaleID = 1,
			BagID=(int)Session["BagId"],
			UserID=1,
			Quantity = (int)Session["Quantity"],
			Price =(double)Session["Price"],
			Total=(double)Session["Total"]


		};
			using (LogoutContext logoutContext = new LogoutContext())
			{
				//logoutContext.Histories.Add(u);
				//logoutContext.SaveChanges();


			}
			return View(u);
		}
		[HttpPost]
		public ActionResult Payment(FormCollection fc)
		{
			//ViewBag.Message = "My contact page.";
			return View();
		}
		public ActionResult AddBag() {
			Bag customer = new Bag()
			{
				BagId = 1,
				BagName = "bbbbbb",
				Price = 56.99F


			};

			return View(customer);
		}

		[HttpPost]
		public ActionResult AddBag(Bag u)
		{
			Bag customer = new Bag()
			{
				BagId = 1,
				BagName = u.BagName,
				Price = u.Price


			};
			using (BagContext bagContext = new BagContext())
			{

				bagContext.Bags.Add(customer);
				bagContext.SaveChanges();

			}

			ViewBag.Message = "Successfully Registered";
			return View(customer);
		}
	}
}