using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
	public class ShopProduct
	{
		[Key]
		public Shop Shop { get; set; }

		[Key]
		public Product Product { get; set; }
		public int Amount { get; set; }
		public decimal Price { get; set; }
	}
}
