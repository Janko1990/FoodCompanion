using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
	public class MealProduct
	{
        public int MealId { get; set; }
        public int ProductId { get; set; }

        public int Amount { get; set; }
        public Meal Meal { get; set; }
        public Product Product { get; set; }
	}

    public class MealProductConfiguration : EntityTypeConfiguration<MealProduct>
    {
        public MealProductConfiguration()
        {
            ToTable("MealProduct");
            HasKey(x => new { x.MealId, x.ProductId });
        }
    }
}
