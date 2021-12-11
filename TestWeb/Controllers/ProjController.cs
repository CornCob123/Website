using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;
using TestWeb.ViewModels;

namespace TestWeb.Controllers

{
    public class ProjController : Controller
    {
		// GET: Proj/Random
		public ActionResult Random()
		{
			var proj = new Proj() { Name = "App" };
			//return View(proj);
			//return Content("Hello World");
			//ViewData["Proj"] = proj;
			//return HttpNotFound();

			var Customers = new List<Customer>() {
			//	new Customer {Name= "Customer 1"},
			//	new Customer {Name= "Customer 2"}

			};

			var ViewModel = new ProjViewModel
			{

				Proj = proj,
				Customer = Customers


			};

				
		
		

			return View(ViewModel);
		}
		[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")] //attribute routes

		public ActionResult ByReleaseDate (int year, int month){

			return Content(year + "/" + month);

		}
		public ActionResult Edit(int ProjID)
		{
			return Content("ID= "+ ProjID);

		}
	
		public ActionResult Index(int? PageIndex, string SortBy)
		{
			if (!PageIndex.HasValue) PageIndex = 1;

			if (String.IsNullOrWhiteSpace(SortBy)) SortBy = "Name";

			return Content(String.Format("pageIndex={0}&sortBy={1}", PageIndex, SortBy));

		}
	}
}