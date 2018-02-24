using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Meal> MealRepository { get; }
		IGenericRepository<MealCategory> MealCategoryRepository { get; }
		IGenericRepository<MealProduct> MealProductRepository { get; }
		IGenericRepository<Product> ProductRepository { get; }
		IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
		IGenericRepository<Shop> ShopRepository { get; }
		IGenericRepository<ShopProduct> ShopProductRepository { get; }

		void Commit();
		void Rollback();
	}
}
