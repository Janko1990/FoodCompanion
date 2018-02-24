using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
	public class MealProduct
	{
		[Key]
		public Meal Meal { get; set; }

		[Key]
		public Product Product { get; set; }

		public int Amount { get; set; }
	}
}
