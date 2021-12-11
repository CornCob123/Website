using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{
	public class LogoutContext :DbContext
	{
		public DbSet<SaleHistory> Histories { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			Database.SetInitializer<LogoutContext>(null);
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Entity<SaleHistory>().ToTable("SalesHistory");
		}
	}
	
}