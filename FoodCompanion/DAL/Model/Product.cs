using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
	public class Product
	{
		[Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public int Id { get; set; }
		public UnitOfMeasure UnitOfMeasure { get; set; }

		[MaxLength( 50 ), Required]
		public string Name { get; set; }
		public int Protein { get; set; }
		public int Carbs { get; set; }
		public int Sugar { get; set; }
		public int Fat { get; set; }
		public int Calories { get; set; }
		public virtual ProductCategory Category { get; set; }
		public List<ShopProduct> Shops { get; set; }
		public List<MealProduct> Meals { get; set; }
	}
}
