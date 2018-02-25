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

		public FoodCompanionContext( string connectionString )
			: base( "name=FoodCompanionEntities" )
		{
			base.Database.Connection.ConnectionString = connectionString;
			this.connectionString = connectionString;
		}

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
		{
			base.OnModelCreating( modelBuilder );

            modelBuilder.Configurations.Add(new MealProductConfiguration());
            modelBuilder.Configurations.Add(new ShopProductConfiguration());
        }

        public DbSet<Meal> Meal { get; set; }
        public DbSet<MealCategory> MealCategory { get; set; }
		internal DbSet<MealProduct> MealProduct { get; set; }
		internal DbSet<Product> Product { get; set; }
		internal DbSet<ProductCategory> ProductCategory { get; set; }
		internal DbSet<Shop> Shop { get; set; }
		internal DbSet<ShopProduct> ShopProduct { get; set; }
	}
}
