using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class FoodCompanionContext : DbContext
	{
		string connectionString;

		internal FoodCompanionContext( string connectionString )
			: base( "name=FoodCompanionEntities" )
		{
			base.Database.Connection.ConnectionString = connectionString;
			this.connectionString = connectionString;
		}

		protected override void OnModelCreating( DbModelBuilder modelBuilder )
		{
			base.OnModelCreating( modelBuilder );
		}

		internal DbSet<Meal> Meal { get; set; }
		internal DbSet<MealCategory> MealCategory { get; set; }
		internal DbSet<MealProduct> MealProduct { get; set; }
		internal DbSet<Product> Product { get; set; }
		internal DbSet<ProductCategory> ProductCategory { get; set; }
		internal DbSet<Shop> Shop { get; set; }
		internal DbSet<ShopProduct> ShopProduct { get; set; }
	}
}
