﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
	public class Shop
	{
		[Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public int Id { get; set; }

		[MaxLength(50), Required]
		public string Name { get; set; }

		public List<ShopProduct> Products { get; set; }
	}
}
