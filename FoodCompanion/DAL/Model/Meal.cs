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
	public class Meal
	{
		[Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public int Id { get; set; }

		[MaxLength( 100 ), Required]
		public string Name { get; set; }
		public int AvgPreparationTime { get; set; }
		public decimal AvgPrice { get; set; }
		public MealDifficulty Difficulty { get; set; }
		[Required]
		public string Recipe { get; set; }
		public string Tips { get; set; }

		public MealCategory Category { get; set; }
		public List<MealProduct> Products { get; set; }
	}
}
