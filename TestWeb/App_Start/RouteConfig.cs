using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestWeb
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapMvcAttributeRoutes();  //using attributes to define routes new method
			routes.MapRoute(
				"project by release date",
				"Projects/Released/{year}/{month}",

				new { controller = "Proj", action = "ByReleaseDate" },  //new route
				new { year = @"\d{4}", month = @"\d{2}" }   //constraint

			);
			routes.MapRoute(
				"Stockapp project",
				"Projects/StockApp",
				new { controller = "Proj", action = "StockApp" }
				
			);
			routes.MapRoute(
				"LoggedIn",
				"Home/LoggedInAfter",
				new { controller = "Home", action = "LoggedInAfter" }

			);

			routes.MapRoute(
				"AddBag",
				"Home/AddBag",
				new { controller = "Home", action = "AddBag" }

			);
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
