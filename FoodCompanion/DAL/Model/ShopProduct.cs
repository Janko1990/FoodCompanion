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
	public class ShopProduct
    {
        public int ShopId { get; set; }
        public int ProductId { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Shop Shop { get; set; }
		public Product Product { get; set; }
	}

    public class ShopProductConfiguration : EntityTypeConfiguration<ShopProduct>
    {
        public ShopProductConfiguration()
        {
            ToTable("ShopProduct");
            HasKey(x => new { x.ShopId, x.ProductId });
        }
    }
}
